using UnityEngine;

public class AlienScript : MonoBehaviour
{
    [Header("Alien Settings")]
    public static float moveSpeed = 1f;  
    public GameObject explosionEffect;  

    private Transform player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();  
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            {
                GameManager.notifyPlayerLifeLost();
                Explode();
            }
    }

    public static void applySlowMotion(){
        moveSpeed = moveSpeed*0.3f;
    }

    public static void removeSlowMotion(){
        moveSpeed = moveSpeed/0.3f;
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