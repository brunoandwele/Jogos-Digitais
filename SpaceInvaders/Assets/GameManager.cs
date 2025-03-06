using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int iEnemyCount = 30;
    public static int iTotalLifes = 3;
    public static float fPlayerPoints = 0.0f;

    public GameObject rareInvaderPrefab;

    private float rareInvaderTimer = 0f;
    private float rareInvaderInterval = 4f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public static void resetGame()
    {
        iTotalLifes = 3;
        fPlayerPoints = 0;
    }

    public static void notifyInvaderDestroyed(int points)
    {
        fPlayerPoints += points;

        if (--iEnemyCount == 0)
        {
            SceneManager.LoadScene("Win");
        }
        else if (iEnemyCount == 20 || iEnemyCount == 10)
        {
            Invaders.notifySpeedIncrement();
        }

    }

    public static void notifyGameLost()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void notifyRareInvaderDestroyed()
    {
        fPlayerPoints += 50;
    }

    public static void notifyLifeLost()
    {
        GameObject heart = GameObject.FindWithTag("Heart");
        Destroy(heart);

        if (--iTotalLifes == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void launchRareInvader()
    {
        Vector3 startPosition = new Vector3(-2.5f, 3.7f, 0.0f);
        Instantiate(rareInvaderPrefab, startPosition, Quaternion.identity);
    }

    void Update()
    {
        rareInvaderTimer += Time.deltaTime;

        if (rareInvaderTimer >= rareInvaderInterval)
        {
            if (Random.Range(0, 100) < 100)
            {
                launchRareInvader();
            }

            rareInvaderTimer = 0f;
        }
    }

    void OnGUI()
    {
        GUIStyle scoreStyle = new GUIStyle();
        scoreStyle.fontSize = 20;
        scoreStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 10, 200, 30), "Pontos: " + fPlayerPoints, scoreStyle);
    }
}