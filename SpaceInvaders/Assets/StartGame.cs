using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public KeyCode start = KeyCode.Return;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(start))
        {
            GameManager.resetGame();
            SceneManager.LoadScene("Game");
        }
    }
}
