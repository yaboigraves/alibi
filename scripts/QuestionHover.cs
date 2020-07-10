using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionHover : MonoBehaviour
{
    // Start is called before the first frame update
    //adjust this to change speed
    float speed;
    //adjust this to change how high it goes
    float height = 0.2f;

    void Start()
    {
        speed = Random.Range(1.3f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, transform.position.y + newY * height, transform.position.z);
    }
}
