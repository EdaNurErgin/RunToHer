using UnityEngine;

public class GroundRepeater : MonoBehaviour
{
    public Transform player;   // Player referansi
    public float groundWidth = 40f; // Bir ground parçasinin genisligi (dünya birimi)

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

        // Player, bu ground parçasinin merkezinden groundWidth kadar ileri giderse
        if (player.position.x - transform.position.x > groundWidth)
        {
            // Bu ground'u ileriye, digerinin önüne ziplat
            transform.position += new Vector3(groundWidth * 2f, 0f, 0f);
        }
    }
}

