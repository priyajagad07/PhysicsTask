using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(1);
            Debug.Log("Coin destroyed");
            Destroy(gameObject);
        }
    }
}
