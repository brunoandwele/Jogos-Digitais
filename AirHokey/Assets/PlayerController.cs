using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa a raquete
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;

        if(pos.x < -5){
            pos.x = -5;
        }else if(pos.x > 5){
            pos.x = 5;
        }
        
        if(pos.y >= 0){
            pos.y = 0;
        }
        else if(pos.y < -5){
            pos.y = -5;
        }


        transform.position = pos;
    }
}
