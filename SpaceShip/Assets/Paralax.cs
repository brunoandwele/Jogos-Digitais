using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    private float lenght;
    public static float parallaxEffectStars = 1.5f;
    public static float parallaxEffectGalaxy = 1f;

    private float speed;

    private string currentTag;

    void Start()
    {
        currentTag = gameObject.tag;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if(currentTag == "stars"){
            speed = parallaxEffectStars;
        }
        else{
            speed = parallaxEffectGalaxy;
        }
        transform.position += Vector3.left * Time.deltaTime * speed;
        if (transform.position.x < -lenght)
        {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }

    }

    public static void applySlowMotion(){
        parallaxEffectStars = parallaxEffectStars*0.2f;
        parallaxEffectGalaxy = parallaxEffectGalaxy*0.2f;
    }

    public static void removeSlowMotion(){
        parallaxEffectStars = parallaxEffectStars/0.2f;
        parallaxEffectGalaxy = parallaxEffectGalaxy/0.2f;
    }
}
