using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour
{
    public bool didTomato, didShylock, didGold;

    public bool tomatoCan, shylock, goldDigger;

    // Start is called before the first frame update
    public int pinned = -1;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        tomatoCan = true;
        shylock = true;
        goldDigger = true;
        didTomato = false;
        didShylock = false;
        didGold = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
