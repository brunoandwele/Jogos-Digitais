using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public KeyCode restart = KeyCode.R;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(restart)){
            GameManager.resetGame();
            SceneManager.LoadScene("Start");
        }
    }
}
