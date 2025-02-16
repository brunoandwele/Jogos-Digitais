using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColider : MonoBehaviour
{
     private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a bola
     private AudioSource audioSource;

    void OnCollisionEnter2D (Collision2D coll) {

        audioSource.Play();

        float rand = Random.Range(-1, 1);
        if(coll.collider.CompareTag("Player")){
            rb2d.AddForce(new Vector2(rand, 300));
        }else if(coll.collider.CompareTag("Boss")){
            rb2d.AddForce(new Vector2(rand, -300));
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        audioSource = GetComponent<AudioSource>();
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
