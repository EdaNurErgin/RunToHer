using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public Transform girl; // kiz objesi 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1) PLAYER kiza ulasti ? WIN
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.LevelComplete();
        }

        // 2) BOT kiza ulasti ? GAME OVER
        if (other.CompareTag("Bot"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.GameOver();
        }
    }
}
