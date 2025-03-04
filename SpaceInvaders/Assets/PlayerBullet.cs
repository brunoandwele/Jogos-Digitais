using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Invader"))
        {
            GameManager.notifyInvaderDestroyed();
            Destroy(collision.gameObject);
            Destroy(gameObject); 
        }
        else if (collision.CompareTag("RareInvader"))
        {
            GameManager.notifyRareInvaderDestroyed();
            RareInvader rareInvader = collision.gameObject.GetComponent<RareInvader>(); 
            if (rareInvader != null)
            {
                rareInvader.ResetInvader(); 
            }
            Destroy(gameObject); 
        }
    }

    void Update()
    {
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
}
