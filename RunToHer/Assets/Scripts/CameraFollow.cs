using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Takip edeceğimiz obje (Player)
    public float xOffset = 2f;     // Oyuncunun biraz önünü göster
    public float smoothSpeed = 5f; // Takip yumuşaklığı

    private void LateUpdate()
    {
        if (target == null) return;

        // Kameranın gitmek istediği pozisyon
        Vector3 desiredPosition = new Vector3(
            target.position.x + xOffset,
            transform.position.y,
            transform.position.z
        );

        // Yumuşak geçiş
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
