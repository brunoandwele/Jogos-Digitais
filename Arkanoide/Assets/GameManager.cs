using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int level1BlockQuantity = 16;
    public static int level2BlockQuantity = 20;
    public static int totalLifes = 3;
    private static AudioSource audioSource;

    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    public static void resetGame(){
        level1BlockQuantity = 16;
        level2BlockQuantity = 20;
        totalLifes = 3;
    }

    public static void NotifyBlockDestruction()
    {

        // Começa a tocar o áudio
        audioSource.Play();

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level1")
        {
            if (--level1BlockQuantity == 0)
            {
                totalLifes = 3;
                SceneManager.LoadScene("Level2");
            }
        }
        else if (scene.name == "Level2")
        {
            if (--level2BlockQuantity == 0)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }

    public static void NotifyLifeLost()
    {
        GameObject heart = GameObject.FindWithTag("Heart"); 
        Destroy(heart);

        if (--totalLifes == 0)
        {
            SceneManager.LoadScene("Lost");
        }
    }
}
