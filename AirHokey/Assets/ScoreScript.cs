using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Ball")
        {
            string wallName = transform.name;
            Placar.Score(wallName);
            BossAI.resetBossPosition();
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
