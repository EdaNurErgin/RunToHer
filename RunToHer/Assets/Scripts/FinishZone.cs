using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public Transform girl; // kız objesi 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1) PLAYER kıza ulaştı → WIN
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.LevelComplete();
        }

        // 2) BOT kıza ulaştı → GAME OVER
        if (other.CompareTag("Bot"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.GameOver();
        }
    }
}
