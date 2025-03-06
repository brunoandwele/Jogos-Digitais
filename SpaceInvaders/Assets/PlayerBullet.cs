using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;

    // Dicionário para mapear tags de inimigos e seus pontos
    private readonly Dictionary<string, int> enemyPoints = new Dictionary<string, int>()
    {
        { "Invader1", 10 },
        { "Invader2", 20 },
        { "Invader3", 30 },
        { "RareInvader", 50 }
    };

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
        if (enemyPoints.ContainsKey(collision.tag))
        {
            int points = enemyPoints[collision.tag];

            if (collision.tag == "RareInvader")
            {
                GameManager.notifyRareInvaderDestroyed();
            }
            else
            {
                GameManager.notifyInvaderDestroyed(points);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Verifica se a bala saiu da tela
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
}