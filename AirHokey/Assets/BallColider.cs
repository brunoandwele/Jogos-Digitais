using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColider : MonoBehaviour
{
     private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a bola

    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(0, 140));
        } else {
            rb2d.AddForce(new Vector2(0, -140));
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        float rand = Random.Range(-2, 2);
        if(coll.collider.CompareTag("Player")){
            rb2d.AddForce(new Vector2(rand, 140));
        }
        else if(coll.collider.CompareTag("Boss")){
            rb2d.AddForce(new Vector2(rand, 140));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoBall", 2);    // Chama a função GoBall após 2 segundos
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
