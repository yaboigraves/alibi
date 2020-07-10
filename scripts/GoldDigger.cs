using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoldDigger : MonoBehaviour
{
    GameStateManager gameStateManager;

    public int heat = 5;
    public string name = "Gold Digger";

    public int nextQuest = 4;


    //all the questions and their responses
    public Dictionary<string, string> questionsAndResponses = new Dictionary<string, string>(){
        {"exit","Oh, I hope this poor old grieving widow was of help to you officer. Please find the bad bad man who killed my bubby."},
        {"Name and date of birth?","He He, Goldie Digger, a lady never reveals her age sir! "},
        {"And what do you do for a living Mrs Digger?","Oh I don’t work, I have no need to. A lady of my stature shouldn’t dirty her hands."},
        {"And where were you on October 3rd 1976, around the afternoon?","I was at this fabulous restaurant Risetti's downtown! Have you ever tried it? ... but then when I got home … I found my poor bubby shot full of holes oh it was horrible!"},
        {"How did you know Mr Digger?", "I’m his wife of course! We married last year in Vienna, oh it was such an extravagant wedding too, he sure knew how to treat a lady."},
        {"What is your relationship with Mr Shylock?","I … like to surround myself with friends who can afford to be around me. I have VERY exquisite taste and Mr Shylock certainly fulfills those … tastes."},
        {"What is your relationship with Mr Can?","Oh that cute boxer, I’ve seen him around a couple times. I don’t bother with anyone that low class for too long though."},
        {"Have you ever shot a gun Mrs Digger?", "Oh me? Heavens no I faint at the sight of blood ... oh you're asking if I've shot a gun? Well Digger had them around so I've shot one before but those are dreadful things guns. "},
        {"How would you describe your relationship with Mr Digger?","Oh we were like a fairytale! It's such a tragedy he's left oh what will I do with all this ... money, and these ... houses and ... cars ..."},
        {"Did Mr Digger have any enemies? Anyone who would want to harm him?","Oh well my Diggie was very very meticulous when it came to security. He had enemies but no one could touch him ... or so he thought. My bubby was betrayed, I'm sure of it. Maybe it was Mr Shylock, or one of his business associates?"},
        {"Have you ever noticed any tension between Mr Digger and Mr Shylock?","Oh I know Shylock very well he he ... he's an ambitious man, but Digger knew that. He made sure no one, not even Shylock knew where he was hiding out. Only people around the house were me and that boxer boy sometimes."},
        {"Ever ride a motorcycle Mrs Digger?","Me? Oh I wouldn't last a second on one of those things!"},
        {"What did you do before you married Mr Digger?","Oh ... I was married to a banker in Prague. He ... passed away due to a freak accident, I was heartbroken. Then I met Digger and we fell deeply in love, it was like fate!"},
        {"Could you describe Mr Can and Mr Diggers relationship?","Hmm ... Digger treated him like a prized thoroughbred race horse. He bet a lot of money on that boy, and Tomato, bless his soul, would try his hardest to lose when Digger tol- ..."},
        {"How do you think someone would go about killing Mr Digger?","Bubby would take a pretty heavy dose of 'sleeping medicine' before he would go to bed. He was out COLD by the time I would get home some nights. Sometimes I would laugh and think to myself how easy it would be to just smother him with a pillow!"},
        {"Do you have anyone who can vouch for your alibi?","Of course sir, I was with Shylock the night the murder took place. Otherwise I might have been shot that night too ... oh it's horrible to think about!"},
        {"Do you own a gun Mrs Digger?","Me?! Heavens no you can barely get me to hold one of those things!"},
        {"How long have you been married to Mr Digger?", "Oh it feels like ages!"},

    };

    Dictionary<string, string> questionsAndGrillResponses = new Dictionary<string, string>(){
        //why would he go home after the match no party?
        {"And where were you on October 3rd 1976, around the afternoon?","... Risetti's was closed that night? ... Well ... I was at Mr Shylock's house ..."},
        {"What is your relationship with Mr Shylock?","... It's ... lonely being married to a man like Digger. Shylock isn't as tough as he seems he's a big softie ..."},
        {"What is your relationship with Mr Can?","... well I just felt so bad for that boy! I loved Digger's money, I mean Digger but gosh did he scare the hell out of that boy. Always telling him he'd kill him this he'd kill him that! "},
        {"How would you describe your relationship with Mr Digger?","... I loved his money too, I'm not afraid to get what I want Sir, but I did not kill my husband if that's what you're suggesting... "},
        {"Could you describe Mr Can and Mr Diggers relationship?","... Digger was rigging matches. He was betting against Tomato when the odds were low, and having the poor kid throw the match so he could win a huge payout ... oh that poor boy was terrified of Digger!"},
        {"How do you think someone would go about killing Mr Digger?", "... not like I ever would of course!"},
        {"How long have you been married to Mr Digger?", "... about a year or so, but we've grown very attached in that short time!"}

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
                    textBox.setText("Hmph! I've had enough of this, talk to my lawyers if you dare to try and speak with me again you rube!");

                    this.suspectLeave();

                }
                else
                {
                    textBox.setText("Excuse me sir? That was VERY rude of you.");
                }
            }
        }

    }

    public void suspectLeave()
    {
        this.gameObject.SetActive(false);
    }
}

