using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int totalCollectedChests;
    private static readonly int totalNecessaryChests = 2;
    private static int playerLifes = 4;

//    private TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI (or Text element)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
//        UpdateScoreboard();
    }

    // Update is called once per frame
    private void Update()
    {
        if (totalCollectedChests > 2)
        {
            //Fim de jogo
            //Transicao para tela de vitoria
        }
    }

    public static void notifyChestCollected()
    {
        //Mostra no placar a quantidade de baus coletadas e quantos faltam
        ++totalCollectedChests;
        Debug.Log("Collected Chest: " + totalCollectedChests + " / " + totalNecessaryChests);

//        // Find the GameManager instance in the scene
//        var instance = FindObjectOfType<GameManager>();
//
//        // Update the scoreboard
//        if (instance != null)
//            instance.UpdateScoreboard();
//        else
//            Debug.LogWarning("GameManager instance missing in the scene!");
    }


//    private void UpdateScoreboard()
//    {
//        // Update the text displayed on the scoreboard
//        if (scoreText != null)
//            scoreText.text = $"Chests: {totalCollectedChests} / {totalNecessaryChests}"; // Example format: "Chests: 3"
//        else
//            Debug.LogWarning("ScoreText is not assigned in the GameManager script!");
//    }


    private static IEnumerator GameOverAfterDelay()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Transition to the defeat screen
        Debug.Log("Game Over: Transitioning to defeat screen...");
        SceneManager.LoadScene("END"); // Carrega a cena de fim de jogo
    }


    public static void notifyLifeLost()
    {
        --playerLifes;

        var heart = GameObject.FindGameObjectWithTag("heart");
        if (heart != null) Destroy(heart);

        if (playerLifes <= 0)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Samurai>().Die();

            // Start a coroutine directly to handle the delay
            FindObjectOfType<GameManager>().StartCoroutine(GameOverAfterDelay());
        }
    }
}