using UnityEngine;
using UnityEngine.SceneManagement;

public class PosteDaVitoria : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que tocou é o jogador
            AvancarFase();
    }

    private void AvancarFase()
    {
        var proximaCena = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(proximaCena);
    }
}