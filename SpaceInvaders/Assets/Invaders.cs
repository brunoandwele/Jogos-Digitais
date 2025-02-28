using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float timerX = 0.0f;
    private float timerY = 0.0f;
    private static float waitTimeX = 1.0f;
    private static float waitTimeY = waitTimeX*2;
    private float speed = 2.0f;

    void ChangeXState(){
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }

    void ChangeYState(){
        var pos = rb2d.transform.position;
        pos.y -= 0.3f;
        rb2d.transform.position = pos;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        timerX += Time.deltaTime;
        timerY += Time.deltaTime;

        if (timerY >= waitTimeY){
            ChangeYState();
            timerY = 0.0f;
        }
        if(timerX >= waitTimeX){
            ChangeXState();
            timerX = 0.0f;
        }

    }
}
