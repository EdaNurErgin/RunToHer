using UnityEngine;

public class BotAI : MonoBehaviour
{
    public float followFactor = 0.9f; // Bot hızının player'a göre oranı
    public float minSpeed = 1f;       // Çok yavaşlamasın

    private Rigidbody2D rb;
    private Transform player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        // Player'ın mevcut hızını al
        float playerSpeed = Mathf.Abs(player.GetComponent<Rigidbody2D>().linearVelocity.x);

        // Bot'un hedef hızı = player hızının belli oranı
        float botSpeed = Mathf.Max(playerSpeed * followFactor, minSpeed);

        rb.linearVelocity = new Vector2(botSpeed, 0f);
    }
}
