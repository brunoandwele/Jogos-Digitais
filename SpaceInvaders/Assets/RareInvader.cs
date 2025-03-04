using UnityEngine;

public class RareInvader : MonoBehaviour
{
    public float speed = 10f;
    public float resetX = -2.7f;
    private bool isVisible = false;
    public float interval = 10f;
    private float timer = 0f;

    void Start(){
        Debug.Log("Init 1");
        gameObject.SetActive(false); 
        Debug.Log("Init 2");
    }

    void Update(){
        timer += Time.deltaTime;
        Debug.Log("Atualizando");

        if (timer >= interval && !isVisible){  
            Debug.Log("Foi, tentando a sorte");
            if (Random.Range(0, 100) < 100){  
                ActivateInvader();
                Debug.Log("Invasor raro ativado.");
                timer = 0f;
            }
        }

        if (isVisible){
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= 2.7f){
                ResetInvader();
            }
        }
    }

    void ActivateInvader(){
        gameObject.SetActive(true);
        transform.position = new Vector3(-2.7f, 4f, 0f);  
        isVisible = true;
        Debug.Log("Invasor raro está visível.");
    }

    public void ResetInvader(){
        transform.position = new Vector3(-2.7f, 4f, 0f);  
        isVisible = false;
        gameObject.SetActive(false);  
        Debug.Log("Invasor raro resetado.");
    }
}
