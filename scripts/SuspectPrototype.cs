using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SuspectPrototype : MonoBehaviour
{
    GameStateManager gameStateManager;

    public int heat = 5;
    public int nextQuest = 4;
    public string name = "Tomato Can";

    public Dictionary<string, string> questionsAndResponses = new Dictionary<string, string>(){
        {"exit","We done? Alright, hope I helped ya detective. I'd keep an eye on ol' Shylock if I was you."},
        {"Name and date of birth?","Tomato Can, April 4th 1945. God I'm getting old now huh."},
        {"And what do you do for a living Mr Can?","I'm a boxer."},
        {"And where were you on October 3rd 1976, around the afternoon?","Uh, I was home. Asleep. I had a big match that night I was tired afterwards and just decided to go home and take it easy."},
        {"How did you know Mr Digger?", "Well ... he's like a father to me, took me off the streets. He liked how I boxed, and especially liked the money I made him. Guess you could say he was my boss."},
        {"What is your relationship with Mr Shylock?","Well, he and Mr Digger were business partners. I don't talk to him much. He doesn't like boxing, says it's barbaric. Funny cause he's definitely not afraid of blood if ya catch my drift."},
        {"What is your relationship with Mrs Digger?","Who? ... Oh, Digger's wife. I don't know her too well, he married her less than a year ago, and not for her personality if ya catch my drift."},
        {"You ever take a fall Mr Can?", "Me?! No way man, I'm a sportsman."},
        {"Have you ever shot a gun Mr Can?", "Ha ha ha! Yeah I went to Nam man, I've shot a couple guns in my life."},
        {"How would you describe your relationship with Mr Digger?","Like I said he's like a father to me. He was tough on me but he believed in me."},
        {"Did Mr Digger have any enemies? Anyone who would want to harm him?","He was a ... violent man, I'm sure there are people who are very happy he's dead now. He's got a lot of people who want him dead, who knows who did him in."},
        {"Have you ever noticed any tension between Mr Digger and his wife?","Her? Nah, she's harmless. He kept her happy with a big, fat allowance but man can that woman burn through cash. Only thing she'd harm is a wallet if ya catch my drift. "},
        {"Ever ride a motorcycle Mr Can?","Nah, never been on one."},
        {"What did you do before you were a boxer?","... I went straight to Nam after high school. After I got back from that there was nothin for me here. No jobs wanted a killer ya know. Eventually military benefits dried up and I was homeless for a while. Then Mr Digger took me in."},
        {"Ever do anything for Mr Digger other than box?","Yeah, I'd do security for him here and there. I would bodyguard for Mrs Digger, but Shylock fired me from that shit a while ago. Had one of his goons doing security for her or something instead."},
        {"Ever been to Mr Diggers estate?","I mean, once or twice yeah for parties. He'd move around alot though, high profile guy like that can't stay in one place too long ya know."},
        {"Could you describe Mr Shylock and Mr Diggers relationship?","Well, Shylock would run a lot of Mr Diggers books, you know he's a money guy a tax guy. He runs his own stint as a loan shark, a lot of people owe him alot of money seems like he's got all of San Francisco under his thumb man."},
        {"Have you ever been arrested Mr Can?","... Yeah, you probably read my record, I killed a man in self defense while I was homeless and got released the next day. He was a junkie who was tryin to rob me one night ... it's kill or be killed out there man."},
        {"How do you think someone would go about killing Mr Digger?","... I mean I don't know, Digger was smart there's no way some random Joe Shmoe like me could off him. Would've have to have been a business rival or something some turf dispute ... dunno."},
        {"Do you have anyone who can vouch for your alibi?","Uh ... no man I was just at my apartment. Nobody but me, I mean you could ask my doorman but yeah, just home."},
        {"Do you own a gun Mr Can?","Yeah I have a uh, couple pistols ya know. I like collecting cowboy revolvers, half of em don't even shoot I just like collecting em."},
        {"How long have you worked for Mr Digger?", "Couple of years now, been boxing in uh, let's say unofficial matches even before I worked for Digger though. But yeah, not too long."},
        {"How do you feel about people betting on your matches?","... It's uh, it's stressful man. Some matches people can win or lose millions of dollars so I always have half the room who hates me by the time the match is over heh ..."},
    };

    Dictionary<string, string> questionsAndGrillResponses = new Dictionary<string, string>(){
        //why would he go home after the match no party?
        {"And where were you on October 3rd 1976, around the afternoon?", "...Yeah."},
        {"What is your relationship with Mrs.Digger?","...I'll be honest with you detective I've been bangin her ... Honestly though just that! I'm not in love with her or nothin, she's the town bicycle she's fucking Shylock too!"},
        {"What is your relationship with Mr Shylock?", "... Shylock and Digger were fixing matches. "},
        {"You ever take a fall Mr Can?", "... Shylock and Digger would have me go down in the fifth some fights. They were makin a lot of money, and I couldn't say no after Mr Digger took me in, I was homeless man I had no choice..."},
        {"How would you describe your relationship with Mr Digger?","... He scared me man, I know he's done some fucked up shit. Most of the people who fucked with him ended up dead ... or worse ..."},
        {"Ever ride a motorcycle Mr Can?", "... I mean I don't own THAT motorcycle. I'm just uh, borrowing one from a friend right now, haven't taken her for a spin yet though heh heh."},
        {"Ever been to Mr Diggers estate?","... I was around ..."},
        {"How do you think someone would go about killing Mr Digger?", "... Look I donno, I'm not a criminal mastermind or nothin ..."},
        {"How do you feel about people betting on your matches?", "... Yeah man Digger got pretty mad at me a couple times I lost him money ... He does not like losing money I'll tell you that ..."}

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
                textBox.setText("Alright, I've had enough of your bullshit man, I'm outta here.");

                this.suspectLeave();

            }
            else
            {
                textBox.setText("Tsk ... fuck off man I'm not afraid of you.");
            }
        }


    }

    public void suspectLeave()
    {
        this.gameObject.SetActive(false);
    }
}
