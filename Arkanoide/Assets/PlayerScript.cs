using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;      
    public KeyCode moveRight = KeyCode.D;     
    public float speed = 5.0f;                
    public float boundX = 3.0f;               
    private Rigidbody2D rb2d;                 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
        rb2d.freezeRotation = true;           
    }

    void Update()
    {
        var vel = rb2d.velocity;              

        if (Input.GetKey(moveLeft))           
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight))     
        {
            vel.x = speed;                   
        }
        else
        {
            vel.x = 0;                        
        }

        rb2d.velocity = vel;                  

        var pos = transform.position;         

        if (pos.x > boundX)                   
        {
            pos.x = boundX;
        }
        else if (pos.x < -boundX)             
        {
            pos.x = -boundX;
        }

        transform.position = pos;             
    }
}
