using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameStateManager gameStateManager;
    //public Button tomatoCan, shylock, goldDigger;
    // Start is called before the first frame update
    public bool tomatoCan, shyLock, goldDigger;
    public bool pinning = false;
    public FadeToBlack fade;

    public Button pinButton;

    public GameObject cigarette;

    bool tomatoTime, goldTime, shyTime;

    bool pinTomatoTime, pinGoldTime, pinShyTime;

    void Start()
    {
        pinButton = GameObject.FindGameObjectWithTag("pin").GetComponent<Button>();
        gameStateManager = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();
        pinButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        tomatoCan = gameStateManager.tomatoCan;
        shyLock = gameStateManager.shylock;
        goldDigger = gameStateManager.goldDigger;

        if (pinning)
        {
            //cigarette.transform.position;
            Vector3 cigPos = Input.mousePosition;
            cigarette.transform.position = new Vector3(cigPos.x, cigPos.y, 0);
            Cursor.visible = true;
        }
        //change this back
        if ((gameStateManager.didGold && gameStateManager.didShylock) && gameStateManager.didTomato)
        {
            pinButton.interactable = true;
        }

        if ((gameStateManager.shylock == false && gameStateManager.tomatoCan == false) && gameStateManager.goldDigger == false)
        {
            pinButton.interactable = true;
        }

        //god this is awful so tired ;()
        if (tomatoTime && fade.faded)
        {
            SceneManager.LoadScene("TomatoCan", LoadSceneMode.Single);

        }

        if (shyTime && fade.faded)
        {
            SceneManager.LoadScene("Shylock", LoadSceneMode.Single);

        }

        if (goldTime && fade.faded)
        {
            SceneManager.LoadScene("GoldDigger", LoadSceneMode.Single);

        }

        //god this is awful so tired ;()
        if (pinTomatoTime && fade.faded)
        {
            SceneManager.LoadScene("PinnedTomato", LoadSceneMode.Single);


        }

        if (pinShyTime && fade.faded)
        {
            SceneManager.LoadScene("PinnedShylock", LoadSceneMode.Single);


        }

        if (pinGoldTime && fade.faded)
        {
            SceneManager.LoadScene("PinnedGold", LoadSceneMode.Single);


        }




    }

    public void selectTomatoCan()
    {
        if (pinning)
        {
            fade.fadeOut();
            pinTomatoTime = true;

        }
        else if (tomatoCan)
        {
            fade.fadeOut();
            tomatoTime = true;
            gameStateManager.didTomato = true;

        }
    }

    public void selectShylock()
    {
        if (pinning)
        {
            fade.fadeOut();
            pinShyTime = true;
        }
        else if (shyLock)
        {
            gameStateManager.didShylock = true;
            fade.fadeOut();
            shyTime = true;

        }
    }

    public void selectGoldDigger()
    {
        if (pinning)
        {
            fade.fadeOut();
            pinGoldTime = true;
        }
        else if (shyLock)
        {
            fade.fadeOut();
            goldTime = true;
            gameStateManager.didGold = true;

        }
    }

    public void pin()
    {
        pinning = true;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
