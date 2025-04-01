using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que colidiu é o player
            CollectCoin();
    }

    private void CollectCoin()
    {
        Debug.Log("Moeda coletada!");
        Destroy(gameObject); // Destroi a moeda após a coleta
    }
}