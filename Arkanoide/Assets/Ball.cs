using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float base_velocity = 18.0f;

    public KeyCode restart = KeyCode.R;  

    private AudioSource audioSource;
    

    void OnCollisionEnter2D(Collision2D coll) {

        // Obtém o componente AudioSource do GameObject
        audioSource = GetComponent<AudioSource>();
        
        // Começa a tocar o áudio
        audioSource.Play();
    
        if (coll.collider.CompareTag("Player")) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Abs(rb2d.velocity.y));
        } 
        else if (coll.collider.CompareTag("Block")) {
            float angleVariation = Random.Range(-0.5f, 0.5f); 
            Vector2 newDirection = new Vector2(rb2d.velocity.x + angleVariation, -Mathf.Abs(rb2d.velocity.y));

            Destroy(coll.gameObject);
            GameManager.NotifyBlockDestruction();
        }
        else if(coll.collider.CompareTag("TopWall")){
            float angleVariation = Random.Range(-10f, 10f); 
            Vector2 newDirection = new Vector2(rb2d.velocity.x + angleVariation, -Mathf.Abs(rb2d.velocity.y));
        }
        else if (coll.collider.CompareTag("Wall")) {
            float angleVariation = Random.Range(-0.5f, 0.5f); 
            Vector2 newDirection = new Vector2(-Mathf.Abs(rb2d.velocity.x), rb2d.velocity.y + angleVariation);
        }

        rb2d.velocity = rb2d.velocity.normalized * base_velocity;
    }


    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(100, -400));
        } else {
            rb2d.AddForce(new Vector2(-100, -400));
        }
    }

    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    

    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        Invoke("GoBall", 2);    
    }


    void Update()
    {
    }
}
