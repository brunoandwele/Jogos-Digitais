using UnityEngine;

public class Paralax : MonoBehaviour
{
    public static float speed = 0.4f;

    private float lenght;

    private void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        if (transform.position.x < -lenght)
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
    }
}