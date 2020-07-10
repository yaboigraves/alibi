using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shylock : MonoBehaviour
{
    GameStateManager gameStateManager;

    public int heat = 3;
    public string name = "Shylock";

    public int nextQuest = 5;

    //all the questions and their responses
    public Dictionary<string, string> questionsAndResponses = new Dictionary<string, string>(){
        {"exit","I hope I was of assistance to you officer, call my office if you ever need anything. Consider what I've said, that boxer is quite the suspicious fella."},
        {"Name and date of birth?","Shylock."},
        {"And what do you do for a living Mr Shylock?","You could say I'm a ... high profile investor of sorts."},
        {"And where were you on October 3rd 1976, around the afternoon?","I was at a boxing match, Mr Can had made quite the upset that night heh. Beat another boxer he was eh ... let's say not supposed to beat. My restaurant Rissetti's was closed so I went home to make dinner."},
        {"How did you know Mr Digger?", "Ah Digger and I go way back. We've been business associates for some time and I run some of his finances for him as well."},
        {"What is your relationship with Mr Can?","Well Tomato's one of Diggers boys. Hired muscle kind of guy, I barely know him, Digger had the good sense to prohibit his employees from talking to business associates."},
        {"What is your relationship with Mrs Digger?","Who? ... Oh, Digger's wife. I don't know her too well, he married her less than a year ago, and not for her personality if ya catch my drift."},
        {"Have you ever shot a gun Mr Shylock?", "Yeah, I've shot a gun before buddy. You ever go all the way with a girl before?"},
        {"How would you describe your relationship with Mr Digger?","We were pretty close, I'm gonna miss that bastard. Kinda like if one of your partners here on the force went down, you're gonna miss em but you know it's just part of the job. That's how I feel."},
        {"Did Mr Digger have any enemies? Anyone who would want to harm him?","Digger was a high profile individual among the let's say 'underground' San Francisco community. Anyone with pockets that deep is bound to have a target on their back."},
        {"Have you ever noticed any tension between Mr Digger and his wife?","... Goldie is uninvolved in this incident if that's what you're implying. I can vouch for her alibi, she was with me the night of the murder at my house after the boxing match. "},
        {"Ever ride a motorcycle Mr Can?","Yeah, I own a dealership actually. Sell em all over town, just sold one to Diggers boy Tomato last week."},
        {"What kind of work would you do for Mr Digger?","Tax advising, business investment, loan acquisition, asset acquisition, the list goes on. Nothing ... illegal of course. "},
        {"Ever been to Mr Diggers estate?","Never in our long partnership have I ever been in that man's home. Digger is very, very careful about who he lets near his place of residence. Only his wife and that boxer he loves so much are ever allowed near his estates."},
        {"Could you describe Mr Can and Mr Diggers relationship?","Tomato Can is Diggers champion! His personal Hercules, man can that kid box. Digger took him off the streets and gave him a chance in the ring, treated him like a father."},
        {"Have you ever been arrested Mr Shylock?","Squeaky clean officer."},
        {"How do you think someone would go about killing Mr Digger?","Hmm... it would have to be a betrayal. No outside could even get close to that man he's untouchable. That being said, he was just a mortal man. Anyone with a key to his house hypothetically could have done it."},
        {"Do you have anyone who can vouch for your alibi?","... Goldie ... er, Mrs Digger can vouch for me, we were at my house the night of the murder. We went there after the boxing match for some refreshments."},
        {"Do you own a gun Mr Can?","Me? No, don't need one. I may be in a dangerous line of work, but I'm by no means a target to anyone, and even if I was I could hire plenty of muscle to keep me safe if I had to."},
        {"Know about any illegal gambling at those boxing matches?","... my attorney advises me only to answer questions relevant to Mr Diggers murder, nothing else officer."}


    };

    Dictionary<string, string> questionsAndGrillResponses = new Dictionary<string, string>(){
        {"And what do you do for a living Mr Shylock?", "... my business is my business officer, I'm not being questioned for my choice of trade am I?"},
        {"What is your relationship with Mr Can?", "... I would bet on his matches here and there. Digger had some very let's say ... specific matches that he told me I couldn't miss betting on Tomato losing."},
        {"Did Mr Digger have any enemies? Anyone who would want to harm him?","Digger was very cautious. I've been his business partner for years and I've never even been in the guys house! Only people who know where he stays are Goldie and his muscle, like Mr Can for example..."},
        {"Have you ever noticed any tension between Mr Digger and his wife?","... my personal relationships are not at all relevant to this investigation officer."},
        {"What kind of work would you do for Mr Digger?", "... we worked together on  several eh, you could say off the books business ventures. The occasional bit of friendly gambling between friends, over boxing matches for example. Harmless honestly harmless."},
        {"Could you describe Mr Can and Mr Diggers relationship?","... The night of the match. Digger told me he was going to kill Tomato. Digger had lost millions of dollars because that kid won the match, If Digger were still here I don't doubt that kid would be in a casket right now. "},
        {"Know about any illegal gambling at those boxing matches?","... there may have been some eh, salacious reorganizing of funds happening. And perhaps, there may have been some matches where Digger and I eh ... had a good idea of the outcome."}


    };
    List<string> questionList;

    public Text question1, question2, question3, nameText;

    TextDisplay textBox;
    string currentQuestion = "";

    int currQuestion1, currQuestion2, currQuestion3;

    void Start()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();

        nameText.text = name;
        //setup lists 
        questionList = new List<string>(questionsAndResponses.Keys);

        //set all the ui stuff to fit
        question1 = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
        question2 = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>();
        question3 = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
        textBox = GameObject.FindGameObjectWithTag("textBox").GetComponent<TextDisplay>();

        this.setQuestions();


    }

    void Update()
    {

    }

    public void setQuestions()
    {
        question1.text = questionList[1];
        question2.text = questionList[2];
        question3.text = questionList[3];

        currQuestion1 = 1;
        currQuestion2 = 2;
        currQuestion3 = 3;
    }

    public void askQuestion(int questionNum)
    {
        switch (questionNum)
        {
            case 1:


                if (nextQuest < questionsAndResponses.Count)
                {
                    currentQuestion = question1.text;

                    currQuestion1 = nextQuest;
                    nextQuest++;
                }
                else
                {

                    currQuestion1 = Random.Range(1, questionList.Count);
                    while (currQuestion1 == currQuestion2 || currQuestion1 == currQuestion3)
                    {
                        currQuestion1 = Random.Range(1, questionList.Count);
                    }
                }
                textBox.setText(questionsAndResponses[question1.text]);
                question1.text = questionList[currQuestion1];
                break;
            case 2:

                if (nextQuest < questionsAndResponses.Count)
                {
                    currentQuestion = question2.text;
                    currQuestion2 = nextQuest;
                    nextQuest++;
                }
                else
                {
                    currentQuestion = question2.text;
                    currQuestion2 = Random.Range(1, questionList.Count);

                    while (currQuestion2 == currQuestion1 || currQuestion2 == currQuestion3)
                    {
                        currQuestion2 = Random.Range(1, questionList.Count);
                    }

                }

                textBox.setText(questionsAndResponses[question2.text]);
                question2.text = questionList[currQuestion2];
                break;
            case 3:

                if (nextQuest < questionsAndResponses.Count)
                {
                    currentQuestion = question3.text;
                    currQuestion3 = nextQuest;
                    nextQuest++;
                }
                else
                {
                    currentQuestion = question3.text;
                    currQuestion3 = Random.Range(1, questionList.Count);


                    while (currQuestion3 == currQuestion1 || currQuestion2 == currQuestion3)
                    {
                        currQuestion3 = Random.Range(1, questionList.Count);
                    }

                }

                textBox.setText(questionsAndResponses[question3.text]);
                question3.text = questionList[currQuestion3];
                break;
        }

    }



    public void grill()
    {
        if (textBox.currentText == textBox.text.text)
        {
            if (questionsAndGrillResponses.ContainsKey(currentQuestion))
            {
                if (heat < 5)
                {
                    heat++;
                }
                textBox.setText(questionsAndGrillResponses[currentQuestion]);
            }
            else
            {
                heat--;

                if (heat <= 0)
                {
                    gameStateManager.goldDigger = false;
                    textBox.setText("I think we're done here Detective, contact my office if you get a warrant.");

                    this.suspectLeave();

                }
                else
                {
                    textBox.setText("Fuck off bozo.");
                }
            }
        }

    }


    public void suspectLeave()
    {
        this.gameObject.SetActive(false);
    }
}

