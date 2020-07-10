using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public FadeToBlack fade;
    public bool starting = false;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (starting && fade.faded)
        {
            SceneManager.LoadScene("Intro", LoadSceneMode.Single);

        }
    }

    public void startGame()
    {

        fade.fadeOut();
        starting = true;
    }
}
