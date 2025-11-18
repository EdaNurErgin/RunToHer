using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    public float girlSpeed = 3f;    // kızın koşma hızı (erkekten düşük tut)
    public Transform player;        // Player referansı

    void Update()
    {
        // Sadece X ekseninde koşsun
        transform.Translate(Vector2.right * girlSpeed * Time.deltaTime);

        // Oyuncu kıza YETİŞTİYSE WIN
        if (player.position.x >= transform.position.x - 0.1f)
        {
            // Win ekranı
            if (GameManager.Instance != null)
                GameManager.Instance.LevelComplete();

            // Kızı durdur
            girlSpeed = 0;
        }
    }
}
