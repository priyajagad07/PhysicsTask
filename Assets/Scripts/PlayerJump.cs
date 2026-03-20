using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 8f;
    public float moveSpeed = 2f;
    public float fallThreshold = -3f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isGameOver)
            return;

        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(transform.position.y < fallThreshold)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        rb.linearVelocity = Vector2.zero;
        Debug.Log("Game Over");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}