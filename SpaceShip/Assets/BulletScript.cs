using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Bullet Settings")]
    private float bulletSpeed = 10f; 
    private float lifetime = 5f;     

    public GameObject explosionEffect; 

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector3 shootDirection)
    {
        rb.velocity = shootDirection.normalized * bulletSpeed;

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            {
                if(collision.tag == "Alien"){
                    GameManager.notifyAlienDestroyed();
                    Destroy(collision.gameObject);
                    Explode();
                    Destroy(gameObject);
                }
            }
    }

    void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}