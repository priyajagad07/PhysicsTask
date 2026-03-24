using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 8f;
    public float moveSpeed = 2f;
    public float fallThreshold = -3f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount = 0;
    public int maxJumps = 5; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.isGameOver)
            return;

        if (Input.GetMouseButtonDown(0) && jumpCount < maxJumps)
        {
            Jump();
        }

        if (transform.position.y < fallThreshold)
        {
            GameManager.instance.GameOver(this);
        }
    }

    void FixedUpdate()
    {
        if (GameManager.isGameOver)
            return;

        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}