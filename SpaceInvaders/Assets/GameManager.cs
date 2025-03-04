using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int iEnemyCount = 30;

    public static int iTotalLifes = 3;

    public static float fPlayerPoints = 0.0f;

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

    public static void resetGame(){
        iTotalLifes = 3;
    }

    
    public static void notifyInvaderDestroyed(){
        iEnemyCount--;
        fPlayerPoints += 5;
    }


    public static void notifyRareInvaderDestroyed(){
        fPlayerPoints += 30;
    }



     public static void notifyLifeLost()
    {
        iTotalLifes--;
        GameObject heart = GameObject.FindWithTag("Heart"); 
        Destroy(heart);

        // if (--totalLifes == 0)
        // {
        //     SceneManager.LoadScene("Lost");
        // }
    }

}
