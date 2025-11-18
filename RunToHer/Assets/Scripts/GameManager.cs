using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // ---------------- SCORE / LEVEL ----------------
    [Header("Score / Level")]
    public int coinCount = 0;
    public int level = 1;
    public int coinsPerLevel = 10;

    [Header("Speed Scaling")]
    public float speedMultiplier = 1f;
    public float speedIncreasePerLevel = 0.2f;

    // ---------------- UI ----------------
    [Header("UI (HUD)")]
    public TMP_Text coinText;   // Oyun sırasında görünen coin yazısı
    public TMP_Text levelText;  // Oyun sırasında görünen level yazısı

    // ---------------- GAME OVER ----------------
    [Header("Game Over")]
    public GameObject gameOverPanel;

    // ---------------- WIN EKRANI ----------------
    [Header("Win Screen")]
    public GameObject winPanel;        // Winner görselinin olduğu panel
    public TMP_Text winCoinsText;      // Sağ üst kutudaki coin yazısı (WinPanel içindeki TMP)


    [Header("Audio")]
    public AudioSource sfxSource;      // Efektleri çalacağımız kaynak
    public AudioClip gameOverClip;     // Bota yakalanma sesi
    public AudioClip winClip;          // Kızı yakalama sesi
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;

        }

        Instance = this;

        // Eğer Inspector'dan atamadıysan, aynı objedeki AudioSource'u al
        if (sfxSource == null)
            sfxSource = GetComponent<AudioSource>();
        // Tek sahneli oyun için şart değil ama istersen açabilirsin:
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
       // Debug.Log("GameManager.Start() çalıştı");

        // Oyun başlarken Game Over paneli kapat
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            //Debug.LogWarning("GameManager: gameOverPanel atanmadı!");
        }

        // Oyun başlarken Win paneli de kapalı olsun
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        else
        {
            //Debug.LogWarning("GameManager: winPanel atanmadı!");
        }

        Time.timeScale = 1f;

        UpdateCoinUI();
        UpdateLevelUI();
    }

    // ---------------- COIN & LEVEL ----------------
    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateCoinUI();

        if (coinCount >= level * coinsPerLevel)
        {
            level++;
            speedMultiplier = 1f + (level - 1) * speedIncreasePerLevel;
            UpdateLevelUI();
        }
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = coinCount.ToString();
    }

    private void UpdateLevelUI()
    {
        if (levelText != null)
            levelText.text = "Lv " + level.ToString();
    }

    // ---------------- GAME OVER ----------------
    public void GameOver()
    {
        //Debug.Log("GameManager.GameOver() ÇAĞRILDI!");
        if (sfxSource != null && gameOverClip != null)
            sfxSource.PlayOneShot(gameOverClip);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            //Debug.Log("GameManager: gameOverPanel aktif edildi.");
        }
        else
        {
            //Debug.LogWarning("GameManager: gameOverPanel REFERANSI YOK!");
        }

        Time.timeScale = 0f;
    }

    // ---------------- WIN / FINISH ----------------
    public void LevelComplete()
    {
        //Debug.Log("GameManager.LevelComplete() ÇAĞRILDI!");
        // Ses: Win
        if (sfxSource != null && winClip != null)
            sfxSource.PlayOneShot(winClip);
        // Oyun dursun
        Time.timeScale = 0f;

        // Win ekranındaki coin yazısını güncelle
        if (winCoinsText != null)
        {
            winCoinsText.text = coinCount.ToString();
        }
        else
        {
            //Debug.LogWarning("GameManager: winCoinsText atanmadı!");
        }

        // Win paneli aç
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            //Debug.Log("GameManager: winPanel aktif edildi.");
        }
        else
        {
            //Debug.LogWarning("GameManager: winPanel REFERANSI YOK!");
        }
    }

    // ---------------- RESTART / MAIN MENU ----------------
    public void RestartLevel()
    {
        //Debug.Log("GameManager.RestartLevel() çağrıldı");

        Time.timeScale = 1f;

        // Panelleri gizle (görsel takılmasın)
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);

        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    // İleride Main Menu sahnesi ekleyince butona bunu bağlayabilirsin
    public void GoToMainMenu()
    {
        //Debug.Log("GameManager.GoToMainMenu() çağrıldı");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Sahne adını kendi menü sahnenle aynı yap
    }

    // ---------------- DEBUG ----------------
    private void Update()
    {
        // Sadece test için: G tuşuna basınca GameOver çağır
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Debug.Log("G tuşuna basıldı, GameOver() manuel çağrılıyor");
            GameOver();
        }
    }


}
