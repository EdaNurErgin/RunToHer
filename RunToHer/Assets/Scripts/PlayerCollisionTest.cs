using UnityEngine;

public class PlayerCollisionTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("PLAYER bir şeye çarptı: " + collision.collider.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("PLAYER TRIGGER ile temas etti: " + other.name);
    }
}
