using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;         
    private float rotationSpeed = 200f;

    private float minX = -4.74f;
    private float maxX = 4.74f;
    private float minY = -2.23f;
    private float maxY = 2.23f;

    public GameObject playerBulletPrefab;  
    public  Transform firePoint;           
    private float shootCooldown = 0.5f;  

    private Rigidbody2D rb;  
    private Vector2 movementInput; 
    private float shootTimer = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        shootTimer += Time.deltaTime; 

        if (Input.GetKeyDown(KeyCode.Space) && shootTimer >= shootCooldown)
        {
            Shoot();
            shootTimer = 0f; 
        }
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
        ClampPosition();
    }

    private void HandleInput()
    {
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.velocity = movementInput * speed;
    }

    private void Rotate()
    {
        if (movementInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void Shoot()
{
    if (playerBulletPrefab != null && firePoint != null)
    {
        Vector3 shootDirection = firePoint.right; 

        GameObject bullet = Instantiate(playerBulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletScript>().Initialize(shootDirection); 
    }
    else
    {
        Debug.LogError("Player Bullet Prefab ou Fire Point não atribuído no Inspector.");
    }
}

}