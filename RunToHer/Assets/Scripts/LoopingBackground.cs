using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public Transform cam;      // Kamerayı buraya sürükleyeceksin
    private float spriteWidth; // Arka planın dünya birimindeki genişliği

    void Start()
    {
        // Bu objenin SpriteRenderer genişliğini al
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteWidth = sr.bounds.size.x;
    }

    void Update()
    {
        // Kamera bu arka planı tamamen geçtiyse
        if (cam.position.x - transform.position.x > spriteWidth)
        {
            // Kendini ileri zıplat (2 sprite genişliği kadar)
            transform.position += new Vector3(spriteWidth * 2f, 0f, 0f);
        }
    }
}
