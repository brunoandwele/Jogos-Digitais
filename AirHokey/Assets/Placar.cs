using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placar : MonoBehaviour
{

    

    public static int Player1Score = 0; // Pontuação do player 1
    public static int BossScore = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola


    public static void Score (string wallID) {
        if (wallID == "TopGoal")
        {
            Player1Score++;
        } else
        {
            BossScore++;
        }
    }


    // Start is called before the first frame update
    void Start () {
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 400, 0, 200, 200), "Player's score: " + Player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 400, 0, 200, 200), "Boss' score: " + BossScore);

        if (GUI.Button(new Rect(Screen.width / 2 - 30, 5, 70, 30), "RESTART"))
        {
            Player1Score = 0;
            BossScore = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
            BossAI.resetBossPosition();
        }
        if (Player1Score == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 500, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            BossAI.resetBossPosition();
        } else if (BossScore == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 + 500, 200, 2000, 1000), "BOSS WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            BossAI.resetBossPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
