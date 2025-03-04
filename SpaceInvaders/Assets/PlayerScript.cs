using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;      
    public KeyCode moveRight = KeyCode.D;     
    public float speed = 5.0f;                
    public float boundX = 3.0f;               
    private Rigidbody2D rb2d;                 
    public GameObject playerBulletPrefab; // Prefab da bala do jogador
    public float shootCooldown = 0.5f; // Cooldown entre os disparos (em segundos)
    private float shootTimer = 0f; // Temporizador para o cooldown

    public float shootOffset = 1.0f; // Distância do jogador até o ponto de disparo

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
        rb2d.freezeRotation = true;           
    }

    void Update()
    {
        var vel = rb2d.velocity;              

        // Movimentação do jogador
        if (Input.GetKey(moveLeft))           
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight))     
        {
            vel.x = speed;                   
        }
        else
        {
            vel.x = 0;                        
        }

        rb2d.velocity = vel;                  

        // Limitação da posição do jogador
        var pos = transform.position;         
        if (pos.x > boundX)                   
        {
            pos.x = boundX;
        }
        else if (pos.x < -boundX)             
        {
            pos.x = -boundX;
        }

        transform.position = pos;             

        // Lógica de disparo com cooldown
        shootTimer += Time.deltaTime; // Atualiza o timer

        if (Input.GetKeyDown(KeyCode.Space) && shootTimer >= shootCooldown) // Se pressionar espaço e o cooldown for zero ou mais
        {
            Shoot(); // Chama a função de disparo
            shootTimer = 0f; // Reseta o timer
        }
    }

    // Função para disparar a bala
    void Shoot()
    {
        if (playerBulletPrefab != null)
        {
            // Calcula a posição do ponto de disparo com base na posição atual do jogador
            Vector3 shootPosition = transform.position + new Vector3(0, shootOffset, 0); // Ajuste o eixo Y conforme necessário

            // Cria a bala na posição calculada
            Instantiate(playerBulletPrefab, shootPosition, Quaternion.identity); 
        }
        else
        {
            Debug.LogError("Player Bullet Prefab não atribuído.");
        }
    }
}
