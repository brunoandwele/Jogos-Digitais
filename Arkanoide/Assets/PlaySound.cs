using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    private AudioSource audioSource;

    void Start()
    {
        // Obtém o componente AudioSource do GameObject
        audioSource = GetComponent<AudioSource>();
        
        // Começa a tocar o áudio
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}