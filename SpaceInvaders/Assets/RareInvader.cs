using UnityEngine;

public class RareInvader : MonoBehaviour
{
    public float speed = 1f; // Velocidade do tiro

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Vector3 pos = transform.position;
        if (pos.x > 3.2)
        {
            Destroy(gameObject);
        }
    }
}
