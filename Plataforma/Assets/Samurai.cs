using UnityEngine;

public class Samurai : MonoBehaviour
{
    public static float health = 100f; // Saúde do samurai
    public float speed = 5f;
    public float climbSpeed = 3f; // Velocidade de subida/descida na escada
    public float attackRange = 1f; // Distância do ataque
    public LayerMask ladderLayer; // Camada das escadas
    private Animator animator;
    private bool canAttack = true;
    private bool isClimbing; // Flag para saber se o samurai está subindo ou descendo
    private Vector2 moveInput;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Entrada de movimento
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Verifica se o samurai está tocando uma escada
        if (IsTouchingLadder() && moveInput.y != 0)
            isClimbing = true; // Se está tocando a escada e tem input vertical, pode subir ou descer
        else
            isClimbing = false; // Caso contrário, o samurai não está na escada

        if (isClimbing)
            ClimbLadder(); // Se está na escada, sobe ou desce
        else
            MoveHorizontal(); // Caso contrário, movimenta-se normalmente

        // Atacar
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            canAttack = false;
            animator.SetTrigger("Attack");
            Attack(); // Chama a função para realizar o ataque e causar dano
            Invoke("ResetAttack", 0.5f);
        }

        // Morrer
        if (Input.GetKeyDown(KeyCode.K)) Die();

        if (!isClimbing)
            rb.gravityScale = 1; // Restaurar gravidade ao sair da escada
        else
            rb.gravityScale = 0; // Sem gravidade ao subir
    }

    // Função para mover o samurai horizontalmente
    private void MoveHorizontal()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y); // Move horizontalmente
        animator.SetBool("isRunning", moveInput.x != 0);

        if (moveInput.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z);
        else if (moveInput.x < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z);
    }

    // Função para subir ou descer a escada
    private void ClimbLadder()
    {
        rb.gravityScale = 0; // Desativar a gravidade enquanto estiver na escada
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveInput.y * climbSpeed);
        animator.SetBool("isClimbing", moveInput.y != 0); // Animação de escada (aqui pode ser configurado)
    }

    // Verifica se o samurai está tocando a escada (usando uma camada específica)
    private bool IsTouchingLadder()
    {
        return Physics2D.OverlapBox(transform.position, new Vector2(0.5f, 0.5f), 0, ladderLayer);
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    public void Die()
    {
        animator.SetTrigger("Death");
        rb.linearVelocity = Vector2.zero; // Para impedir que o personagem continue se movendo
        GetComponent<Collider2D>().enabled = false; // Desativar o collider para evitar colisões
        rb.gravityScale = 1;
        Invoke("DestroyCharacter", 2f); // Ajuste o tempo conforme necessário
    }

    private void DestroyCharacter()
    {
        gameObject.SetActive(false); // Pode ser substituído por Destroy(gameObject) se quiser remover o objeto
    }

    // Função para o samurai levar dano
    public void TakeDamage(float damage)
    {
        GameManager.notifyLifeLost();
    }

    // Função para o samurai atacar e verificar colisão com o esqueleto
    private void Attack()
    {
        var entityHit = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Enemy"));

        foreach (var entity in entityHit)
            if (entity.CompareTag("enemy"))
            {
                entity.GetComponent<Skeleton>().TakeDamage(10); // Ajuste o dano conforme necessário
                Debug.Log("Esqueleto levou dano!");
            }
    }
}