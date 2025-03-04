using UnityEngine;

public class InvaderBullet : MonoBehaviour
{
    public float speed = 1f; // Velocidade do tiro

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        Vector3 pos = transform.position;
        if (pos.y < -6){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.notifyLifeLost();
            Destroy(gameObject); // Destroi a bala
        }
    }
}
