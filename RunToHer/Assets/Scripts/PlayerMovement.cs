using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed Settings")]
    public float maxSpeed = 12f;        // Level 1'deki temel max hız
    public float acceleration = 20f;    // Gaz basarken hızlanma hızı
    public float deceleration = 25f;    // Tuş bırakınca yavaşlama hızı

    // ses jump
    [Header("Audio")]
    public AudioSource audioSource;     // Player üzerindeki AudioSource
    public AudioClip jumpClip;          // Zıplama sesi

    [Header("Jump Settings")]
    public float jumpForce = 8f;        // Zıplama gücü

    private float currentSpeed;         // O anki yatay hız
    private float inputX;               // -1 / 0 / 1
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0f;

        // Eğer Inspector'dan atamadıysan, aynı objedeki AudioSource'u al
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Klavyeden yön al
        inputX = Input.GetAxisRaw("Horizontal");

        // 🔥 GameManager'dan hız çarpanını al
        float speedMultiplier = 1f;
        if (GameManager.Instance != null)
            speedMultiplier = GameManager.Instance.speedMultiplier;

        // Level'e göre efektif max hız
        float effectiveMaxSpeed = maxSpeed * speedMultiplier;

        // Hedef hız: yön * efektif max hız
        float targetSpeed = inputX * effectiveMaxSpeed;

        // Hız farkı
        float speedDiff = targetSpeed - currentSpeed;

        // Tuşa basıyorsan acceleration, bırakmışsan deceleration
        float accelRate = Mathf.Abs(targetSpeed) > 0.01f ? acceleration : deceleration;

        // Yumuşak hız geçişi
        currentSpeed += speedDiff * accelRate * Time.deltaTime;

        // Güvenlik: -effectiveMax ile +effectiveMax arası
        currentSpeed = Mathf.Clamp(currentSpeed, -effectiveMaxSpeed, effectiveMaxSpeed);

        // Çok kaba grounded kontrolü (istersen raycastli halini eklemiştik)
        bool isGrounded = Mathf.Abs(rb.linearVelocity.y) < 0.01f;

        // Space → sadece yerdeyken zıpla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            // Zıplama sesi çal
            if (audioSource != null && jumpClip != null)
            {
                audioSource.PlayOneShot(jumpClip);
            }
        }
    }

    private void FixedUpdate()
    {
        // X ekseninde currentSpeed, Y ekseninde mevcut düşüş/zıplama
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
    }
}
