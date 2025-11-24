using UnityEngine;

public class BotAI : MonoBehaviour
{
    public float followFactor = 0.9f; // Bot hizinin player'a göre orani
    public float minSpeed = 1f;       // Çok yavaslamasin

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

        // Player'in mevcut hizini al
        float playerSpeed = Mathf.Abs(player.GetComponent<Rigidbody2D>().linearVelocity.x);

        // Bot'un hedef hizi = player hizinin belli orani
        float botSpeed = Mathf.Max(playerSpeed * followFactor, minSpeed);

        rb.linearVelocity = new Vector2(botSpeed, 0f);
    }
}
