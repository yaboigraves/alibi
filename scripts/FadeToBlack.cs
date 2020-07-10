using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeToBlack : MonoBehaviour
{
    public CanvasGroup canvas;
    public float fadeOutTime = 2.0f;
    float maxFadeOut;
    float maxFadeIn;
    public float fadeInTime = 2.0f;

    public bool fadingIn = true;
    public bool fadingOut = false;

    public bool faded = false;
    // Start is called before the first frame update
    void Start()
    {
        maxFadeIn = fadeInTime;
        maxFadeOut = fadeOutTime;
        fadeOutTime = 0;
        canvas = GetComponent<CanvasGroup>();
        canvas.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            canvas.alpha = fadeInTime / maxFadeIn;
            fadeInTime -= Time.deltaTime;
            if (fadeInTime <= 0)
            {
                fadingIn = false;
            }
        }

        if (fadingOut)
        {
            fadeOutTime += Time.deltaTime;
            canvas.alpha = fadeOutTime / maxFadeOut;
            if (fadeOutTime >= maxFadeOut)
            {

                faded = true;
            }
        }
    }

    public void fadeOut()
    {
        fadingOut = true;
    }
}
