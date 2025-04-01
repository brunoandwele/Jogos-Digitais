using System.Collections;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Transform samurai; // Referência para o personagem samurai
    public float moveSpeed = 2f; // Velocidade de movimento
    public float attackRange = 2f; // Distância mínima para o ataque
    public float attackDelay = 1f; // Delay entre os ataques

    public float viewDistance = 5f; // Distância de visão para o esqueleto
    private Animator animator; // Referência ao Animator

    private float health = 20f; // Saúde do esqueleto
    private bool isAttacking; // Controla se o esqueleto está atacando
    private Rigidbody2D rb; // Referência ao Rigidbody2D

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Verifica se o samurai está à vista e se está dentro do alcance
        if (samurai != null)
        {
            var distanceToSamurai = Vector2.Distance(transform.position, samurai.position);

            // Se o samurai está dentro do alcance de ataque, começa a atacar
            if (distanceToSamurai <= attackRange && !isAttacking)
            {
                StopMovement(); // Para de se mover
                Attack(); // Começa o ataque
            }
            // Se o samurai sai do alcance de ataque, o esqueleto deve voltar a perseguir
            else if (distanceToSamurai > attackRange && !isAttacking)
            {
                if (distanceToSamurai < viewDistance) MoveTowardsSamurai(); // Volta a se mover em direção ao samurai
            }
        }
    }

    private void MoveTowardsSamurai()
    {
        animator.SetBool("isRunning", true); // Inicia animação de corrida

        // Move o esqueleto em direção ao samurai
        Vector2 direction = (samurai.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);

        // Ajusta a direção do sprite para o lado certo
        if (rb.linearVelocity.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z);
        else if (rb.linearVelocity.x < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z);
    }

    private void StopMovement()
    {
        rb.linearVelocity = Vector2.zero; // Para o movimento assim que o esqueleto chega ao alcance de ataque
        animator.SetBool("isRunning", false); // Para a animação de corrida
    }

    private void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack"); // Executa animação de ataque

        var distanceToSamurai = Vector2.Distance(transform.position, samurai.position);

        // Se o samurai está dentro do alcance de ataque, começa a atacar
        if (distanceToSamurai <= attackRange)
        {
            // Pega o objeto com a tag player e chama o método TakeDamage
            var samuraiObject = GameObject.FindGameObjectWithTag("Player");
            if (samuraiObject != null)
            {
                var samuraiScript = samuraiObject.GetComponent<Samurai>(); // Obtém o componente Samurai
                if (samuraiScript != null) samuraiScript.TakeDamage(25); // Aplica dano ao samurai
            }
        }

        // Espera o tempo do delay para voltar ao estado normal
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        // Aguarda a animação de ataque terminar antes de permitir outro ataque
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }

    // Função para o esqueleto levar dano
    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt"); // Inicia animação de dano

        if (health <= 0) Die();
    }

    // Função para o esqueleto morrer
    private void Die()
    {
        animator.SetTrigger("Die"); // Inicia animação de morte
        enabled = false; // Desativa o componente
        Destroy(gameObject, 1f); // Destroi o esqueleto após a animação de morte
    }
}