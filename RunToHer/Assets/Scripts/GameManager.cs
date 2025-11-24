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
    public TMP_Text coinText;   // Oyun sirasinda görünen coin yazisi
    public TMP_Text levelText;  // Oyun sirasinda görünen level yazisi

    // ---------------- GAME OVER ----------------
    [Header("Game Over")]
    public GameObject gameOverPanel;

    // ---------------- WIN EKRANI ----------------
    [Header("Win Screen")]
    public GameObject winPanel;        // Winner görselinin oldugu panel
    public TMP_Text winCoinsText;      // Sag üst kutudaki coin yazisi (WinPanel içindeki TMP)


    [Header("Audio")]
    public AudioSource sfxSource;      // Efektleri çalacagimiz kaynak
    public AudioClip gameOverClip;     // Bota yakalanma sesi
    public AudioClip winClip;          // Kizi yakalama sesi
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;

        }

        Instance = this;

        // Eger Inspector'dan atamadiysan, ayni objedeki AudioSource'u al
        if (sfxSource == null)
            sfxSource = GetComponent<AudioSource>();
        // Tek sahneli oyun için sart degil ama istersen açabilirsin:
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
       // Debug.Log("GameManager.Start() çalisti");

        // Oyun baslarken Game Over paneli kapat
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            //Debug.LogWarning("GameManager: gameOverPanel atanmadi!");
        }

        // Oyun baslarken Win paneli de kapali olsun
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        else
        {
            //Debug.LogWarning("GameManager: winPanel atanmadi!");
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
        //Debug.Log("GameManager.GameOver() ÇAGRILDI!");
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
        //Debug.Log("GameManager.LevelComplete() ÇAGRILDI!");
        // Ses: Win
        if (sfxSource != null && winClip != null)
            sfxSource.PlayOneShot(winClip);
        // Oyun dursun
        Time.timeScale = 0f;

        // Win ekranindaki coin yazisini güncelle
        if (winCoinsText != null)
        {
            winCoinsText.text = coinCount.ToString();
        }
        else
        {
            //Debug.LogWarning("GameManager: winCoinsText atanmadi!");
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
        //Debug.Log("GameManager.RestartLevel() çagrildi");

        Time.timeScale = 1f;

        // Panelleri gizle (görsel takilmasin)
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);

        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    // Ileride Main Menu sahnesi ekleyince butona bunu baglayabilirsin
    public void GoToMainMenu()
    {
        //Debug.Log("GameManager.GoToMainMenu() çagrildi");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Sahne adini kendi menü sahnenle ayni yap
    }

    // ---------------- DEBUG ----------------
    private void Update()
    {
        // Sadece test için: G tusuna basinca GameOver çagir
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Debug.Log("G tusuna basildi, GameOver() manuel çagriliyor");
            GameOver();
        }
    }


}
