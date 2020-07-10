using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDisplay : MonoBehaviour
{
    public AudioSource[] voices;

    AudioSource currentAudio;
    public Text nameText;
    public Text text;
    public string currentText = "";
    public int currentLetter = 0;
    public float periodTime = 0.5f;

    public float letterDeltaTime;

    public float holdingSpaceTime = 0.00000001f;

    public bool holdingSpace = false;


    public float maxLetterDeltaTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        currentAudio = voices[0];
        letterDeltaTime = maxLetterDeltaTime;
        nameText = transform.parent.GetChild(0).GetComponent<Text>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {




        if (letterDeltaTime > 0)
        {
            letterDeltaTime -= Time.deltaTime;
        }

        else
        {

            if (text.text != currentText)
            {
                text.text += currentText[currentLetter];



                currentLetter++;

                if (currentText[currentLetter - 1] == '.')
                {
                    letterDeltaTime += periodTime;
                }
                else
                {

                    if (!currentAudio.isPlaying || currentAudio == null)
                    {
                        currentAudio = voices[Random.Range(0, voices.Length - 1)];
                        currentAudio.Play();
                    }

                    if (holdingSpace)
                    {
                        letterDeltaTime = maxLetterDeltaTime;
                    }
                    else
                    {
                        letterDeltaTime = holdingSpaceTime;
                    }

                }
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            holdingSpace = false;
        }
        else
        {
            holdingSpace = true;
        }
    }

    public void setText(string textArg)
    {

        text.text = "";
        currentLetter = 0;
        currentText = textArg;
    }
}
