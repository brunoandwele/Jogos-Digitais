using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timerX = 0.0f;
    private float timerY = 0.0f;
    private static float waitTimeX = 3f;
    private static float waitTimeY = waitTimeX * 2;
    private static float speed = 0.4f;

    public GameObject invaderBulletPrefab; 
    public float shootInterval = 10f; 
    private float shootTimer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        timerX += Time.deltaTime;
        timerY += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (timerY >= waitTimeY)
        {
            ChangeYState();
            timerY = 0.0f;
        }
        if (timerX >= waitTimeX)
        {
            ChangeXState();
            timerX = 0.0f;
        }

        if (shootTimer >= shootInterval)
        {
            if (Random.Range(0, 100) < 3) 
            {
                Shoot();
             
            }
            shootTimer = 0f;
        }

        if (transform.position.y < -3.3f)
        {
            GameManager.notifyGameLost();
        }

    }

    void ChangeXState()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x * -1, rb2d.velocity.y);
    }

    void ChangeYState()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);
    }

    void Shoot()
    {
        // Instancia a bala na posição do inimigo e sem rotação
        GameObject bullet = Instantiate(invaderBulletPrefab, transform.position, Quaternion.identity);
    }

    public static void notifySpeedIncrement()
    {
        speed = speed*3;
        waitTimeY = waitTimeY/3;
        waitTimeX = waitTimeX/3;
    }

    public static void notifyResetParameters()
    {
        waitTimeX = 3f;
        waitTimeY = waitTimeX * 2;
        speed = 0.4f;
    }
}
