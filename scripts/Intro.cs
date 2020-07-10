using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] introLines;
    public TextDisplay textD;
    public int currentTextLine = 0;
    public bool intro = true;

    public FadeToBlack fade;
    void Start()
    {
        textD.setText(introLines[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (textD.currentLetter >= introLines[currentTextLine].Length)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (currentTextLine < introLines.Length - 1)
                {
                    currentTextLine++;
                }

                if (currentTextLine <= introLines.Length - 1)
                {

                    textD.setText(introLines[currentTextLine]);
                }



            }
        }

        if (currentTextLine >= introLines.Length - 1)
        {
            fade.fadeOut();
            if (intro)
            {
                if (fade.faded)
                {
                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);

                }

            }
            else
            {
                if (fade.faded)
                {
                    SceneManager.LoadScene("Start Menu", LoadSceneMode.Single);

                }
            }

        }

    }
}
