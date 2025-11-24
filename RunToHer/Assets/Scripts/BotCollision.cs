using UnityEngine;

public class BotCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Bot TRIGGER temas algiladi: " + other.name);

        // Sadece Player'a tepki ver
        if (!other.CompareTag("Player")) return;

        Debug.Log("Bot PLAYER'a degdi, GameOver çagriliyor!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            //Debug.LogWarning("GameManager.Instance YOK!");
        }
    }
}
