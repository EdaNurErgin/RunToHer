using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Takip edecegimiz obje (Player)
    public float xOffset = 2f;     // Oyuncunun biraz önünü göster
    public float smoothSpeed = 5f; // Takip yumusakligi

    private void LateUpdate()
    {
        if (target == null) return;

        // Kameranin gitmek istedigi pozisyon
        Vector3 desiredPosition = new Vector3(
            target.position.x + xOffset,
            transform.position.y,
            transform.position.z
        );

        // Yumusak geçis
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
