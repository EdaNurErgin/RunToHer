using UnityEngine;

public class GroundRepeater : MonoBehaviour
{
    public Transform player;   // Player referansı
    public float groundWidth = 40f; // Bir ground parçasının genişliği (dünya birimi)

    private void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;
        }
    }

    private void Update()
    {
        if (player == null) return;

        // Player, bu ground parçasının merkezinden groundWidth kadar ileri giderse
        if (player.position.x - transform.position.x > groundWidth)
        {
            // Bu ground'u ileriye, diğerinin önüne zıplat
            transform.position += new Vector3(groundWidth * 2f, 0f, 0f);
        }
    }
}

