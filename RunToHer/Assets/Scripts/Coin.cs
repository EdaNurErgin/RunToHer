using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sadece Player çarptiginda çalissin
        if (!other.CompareTag("Player")) return;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoin(value);
        }

        // Coin toplandiktan sonra yok et
        Destroy(gameObject);
    }
}
