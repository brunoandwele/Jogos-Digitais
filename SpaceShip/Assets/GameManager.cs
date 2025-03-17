using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int iTotalLifes = 3;
    private static int iTotalPoints = 0;
    private float minX = -4.74f;   // Limite esquerdo do mapa
    private float maxX = 4.74f;    // Limite direito do mapa
    private float minY = -2.23f;   // Limite inferior do mapa
    private float maxY = 2.23f;    // Limite superior do mapa
    private float spawnRange = 1f;   // Distância mínima para o alien gerar fora do mapa
    private float fSpawnRate = 20f;
    public GameObject alienPrefab;  // Prefab do alien
    private static bool bIsOnSlowMotion = false;
    private static float fSlowMotionInterval = 4f;
    private static float fSlowMotionTimer = 0;
    private static int iMaxAlienQuantity = 15;
    private static int iTotalAlienQuantity = 0;  // Correção no nome
    private static bool bIsGameRunning = true;  // Inicializando para que o jogo comece
    public static void resetGame()
    {
        iTotalLifes = 3;
        iTotalPoints = 0;
        iTotalAlienQuantity = 0; 
        bIsOnSlowMotion = false;
        fSlowMotionTimer = 0;
        bIsGameRunning = true;
    }

    public static void notifyPlayerLifeLost()
    {
        iTotalAlienQuantity--;
        iTotalLifes--;
        GameObject heart = GameObject.FindWithTag("Heart");
        Destroy(heart);
    }

    public static void notifyAlienDestroyed()
    {
        iTotalAlienQuantity--;
        iTotalPoints += 10;
    }

    private void generateAliens()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue < fSpawnRate && iTotalAlienQuantity < iMaxAlienQuantity)
        {
            Vector3 spawnPosition = GetRandomPosition();

            Instantiate(alienPrefab, spawnPosition, Quaternion.identity);
            iTotalAlienQuantity++;  // Aumenta a quantidade de aliens
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        spawnPosition.x = Random.Range(maxX + spawnRange, maxX + spawnRange * 2);  // Fora à direita

        if (Random.Range(0, 2) == 0)
        {
            spawnPosition.x = Random.Range(minX - spawnRange * 2, minX - spawnRange); // Fora à esquerda
        }

        spawnPosition.y = Random.Range(maxY + spawnRange, maxY + spawnRange * 2);  // Fora acima

        if (Random.Range(0, 2) == 0)
            spawnPosition.y = Random.Range(minY - spawnRange * 2, minY - spawnRange); // Fora abaixo

        spawnPosition.z = 0f;

        return spawnPosition;
    }

    void Start()
    {
        resetGame();
    }

    void Update()
    {
        if (bIsGameRunning){
        if (iTotalLifes == 0)
        {
            SceneManager.LoadScene("End");
            bIsGameRunning = false;
        }
        else{
        
            if (iTotalAlienQuantity < iMaxAlienQuantity)
            {
                generateAliens(); 
            }
        }

        if (iTotalPoints > 0 && iTotalPoints % 50 == 0 && !bIsOnSlowMotion)
        {
            bIsOnSlowMotion = true;
            AlienScript.applySlowMotion();
            Paralax.applySlowMotion();
        }

        if (bIsOnSlowMotion)
        {
            fSlowMotionTimer += Time.deltaTime;
            if (fSlowMotionTimer >= fSlowMotionInterval)
            {
                bIsOnSlowMotion = false;
                fSlowMotionTimer = 0f;
                AlienScript.removeSlowMotion();
                Paralax.removeSlowMotion();
            }
        }
        }
    }


    void OnGUI()
    {
        GUIStyle labelStyle = new GUIStyle();
        labelStyle.fontSize = 24; 
        labelStyle.normal.textColor = Color.white; 

        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 70, 200, 50), "Pontos: " + iTotalPoints, labelStyle);
        GUI.Label(new Rect(20, 20, 200, 50), "Vidas: " + iTotalLifes);

    }


    public static void DestroyAllAliens()
    {
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien"); // Encontra todos os objetos com a tag "Alien"

        foreach (GameObject alien in aliens)
        {   
            Destroy(alien); // Destroi cada um deles
        }
    }   


}