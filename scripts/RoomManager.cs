using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    //public SuspectPrototype suspect;

    //public Transform cig;
    TextDisplay textBox;

    public FadeToBlack fade;
    public float fadeToMenuTime = 5.0f;
    public string exitText;
    public bool fading;

    public bool goingToMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        textBox = GameObject.FindGameObjectWithTag("textBox").GetComponent<TextDisplay>();

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 cigPos = (Input.mousePosition);
        // cig.position = new Vector3(cigPos.x, cigPos.y, 0);

        if (goingToMenu)
        {
            if (fadeToMenuTime >= 0)
            {
                fadeToMenuTime -= Time.deltaTime;
                fade.fadeOut();
            }
            else
            {
                if (fade.faded)
                {
                    fadeToMenuTime = 1.0f;

                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                }

            }


        }
    }

    public void backToMenu()
    {

        textBox.setText(exitText);

        goingToMenu = true;
    }
}
