using UnityEngine;

public class Escada : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyCode upArrow = KeyCode.UpArrow; // direita

    public Rigidbody2D playerRb;

    private readonly float speed = 8f;

    private bool escada;

    private bool escalando;

    private void Start()
    {
    }


    private void Update()
    {
        if (escada && Input.GetKey(KeyCode.W))
            escalando = true;
        else
            escalando = false;

        if (escalando)
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, speed); //subir escada
        else
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 0); //parar de subir escada
    }

    private void FixedUpdate()
    {
        if (escalando)
        {
            //tira a gravidade
            playerRb.gravityScale = 0f; //tira a gravidade
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, speed);
        }
        else
        {
            playerRb.gravityScale = 20.0f; //coloca a gravidade de volta
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //subir escada
        if (collision.CompareTag("escada")) escada = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //saiu da escada

        if (collision.CompareTag("escada"))
        {
            escada = false;
            escalando = false;
        }
    }
}