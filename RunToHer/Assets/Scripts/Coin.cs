using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sadece Player çarptığında çalışsın
        if (!other.CompareTag("Player")) return;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoin(value);
        }

        // Coin toplandıktan sonra yok et
        Destroy(gameObject);
    }
}
