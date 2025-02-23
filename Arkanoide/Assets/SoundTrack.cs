using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrack : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obtém o componente AudioSource do GameObject
        audioSource = GetComponent<AudioSource>();
        
        // Define o áudio para tocar em loop
        audioSource.loop = true;
        
        // Começa a tocar o áudio
        audioSource.Play();
    }
}
