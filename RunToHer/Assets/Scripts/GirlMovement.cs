using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    public float girlSpeed = 3f;    // kizin kosma hizi (erkekten düsük tut)
    public Transform player;        // Player referansi

    void Update()
    {
        // Sadece X ekseninde kossun
        transform.Translate(Vector2.right * girlSpeed * Time.deltaTime);

        // Oyuncu kiza YETISTIYSE WIN
        if (player.position.x >= transform.position.x - 0.1f)
        {
            // Win ekrani
            if (GameManager.Instance != null)
                GameManager.Instance.LevelComplete();

            // Kizi durdur
            girlSpeed = 0;
        }
    }
}
