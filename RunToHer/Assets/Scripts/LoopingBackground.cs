using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public Transform cam;      // Kamerayi buraya sürükleyeceksin
    private float spriteWidth; // Arka planin dünya birimindeki genisligi

    void Start()
    {
        // Bu objenin SpriteRenderer genisligini al
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteWidth = sr.bounds.size.x;
    }

    void Update()
    {
        // Kamera bu arka plani tamamen geçtiyse
        if (cam.position.x - transform.position.x > spriteWidth)
        {
            // Kendini ileri ziplat (2 sprite genisligi kadar)
            transform.position += new Vector3(spriteWidth * 2f, 0f, 0f);
        }
    }
}
