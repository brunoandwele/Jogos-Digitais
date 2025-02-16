using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private static Rigidbody2D rb2d;
    private  GameObject theBall;
    public float bossSpeed = 2.0f; // Velocidade do boss

    public static Vector2 initialBossPositon;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialBossPositon = rb2d.position;
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Encontra a bola
    }

    public static void resetBossPosition(){
        rb2d.position = initialBossPositon;
    }

    void Update()
    {
        if (theBall == null) return; 

        Vector2 vel = rb2d.velocity; 
        Vector2 ballPos = theBall.transform.position;
        Vector2 bossPos = rb2d.position;


        if (bossPos.y >= 5 && ballPos.y >= 0) {
            vel.y = Mathf.Min(vel.y, 0); 
        }
        else if (ballPos.x > bossPos.x)
            vel.x = bossSpeed;
        else if (ballPos.x < bossPos.x)
            vel.x = -bossSpeed;
        else
            vel.x = 0; 


        if (bossPos.y <= 0 && ballPos.y <= 0) {
            vel.y = Mathf.Max(vel.y, 0); 
        }
        else if (ballPos.y > bossPos.y)
            vel.y = bossSpeed;
        else if (ballPos.y < bossPos.y)
            vel.y = -bossSpeed;
        else
            vel.y = 0; 

        rb2d.velocity = vel; 
    }
}
