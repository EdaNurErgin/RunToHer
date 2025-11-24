using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;   // Player referansi

    [Header("Prefabs")]
    [SerializeField] private GameObject[] coinPrefabs;
    [SerializeField] private GameObject[] obstaclePrefabs; // Varil, diken vs.

    [Header("Spawn Settings")]
    [SerializeField] private float spawnAheadDistance = 25f;   // Player’in önünde ne kadar ileride spawn
    [SerializeField] private float minDistanceBetweenSpawns = 3f;
    [SerializeField] private float maxDistanceBetweenSpawns = 6f;

    [Header("Y Pozisyonlari")]
    [SerializeField] private float groundY = 2f;      // Engel için zemin yüksekligi
    [SerializeField] private float coinMinY = 3f;     // Coin’ler için min Y
    [SerializeField] private float coinMaxY = 4.5f;   // Coin’ler için max Y

    private float nextSpawnX;

    private void Start()
    {
        // Player atanmadiysa tag üzerinden bul
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;
        }

        if (player != null)
        {
            // Ilk spawn baslangiç X’i
            nextSpawnX = player.position.x + 10f;
        }
    }

    private void Update()
    {
        if (player == null) return;

        // Player’in ilerisinde, su kadar mesafeye kadar her frame spawn’i doldur
        float targetX = player.position.x + spawnAheadDistance;

        while (nextSpawnX < targetX)
        {
            SpawnRandomItem(nextSpawnX);

            // Base aralik
            float distance = Random.Range(minDistanceBetweenSpawns, maxDistanceBetweenSpawns);

            // Oyun hizlandikça araliklari biraz kisalt (opsiyonel, ama güzel his verir)
            float multiplier = 1f;
            if (GameManager.Instance != null)
                multiplier = GameManager.Instance.speedMultiplier;

            distance /= Mathf.Max(multiplier, 0.5f);

            nextSpawnX += distance;
        }
    }

    private void SpawnRandomItem(float xPos)
    {
        // Basit oran: %60 coin, %40 engel
        bool spawnCoin = Random.value > 0.4f;

        if (spawnCoin && coinPrefabs.Length > 0)
        {
            GameObject prefab = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
            float y = Random.Range(coinMinY, coinMaxY);
            Instantiate(prefab, new Vector3(xPos, y, 0f), Quaternion.identity);
        }
        else if (obstaclePrefabs.Length > 0)
        {
            GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(prefab, new Vector3(xPos, groundY, 0f), Quaternion.identity);
        }
    }
}
