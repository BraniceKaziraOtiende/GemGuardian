using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI")]
    public Text gemTextScore;  // "GemText" - shows "x5"
    public Text healthText;    // "HealthText" - shows "Health: 100"

    [Header("Audio")]
    private AudioSource audioManager;

    private int gemCount = 0;      // Gems collected
    private float waveTimer = 0f;  // Enemy waves

    void Awake()
    {
        Instance = this;
        audioManager = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Auto-find UI Texts
        if (gemTextScore == null)
            gemTextScore = GameObject.Find("GemText")?.GetComponent<Text>();

        if (healthText == null)
            healthText = GameObject.Find("HealthText")?.GetComponent<Text>();

        // Initial UI
        if (gemTextScore != null) gemTextScore.text = "x0";
        if (healthText != null) healthText.text = "Health: 100";
    }

    void Update()
    {
        // Enemy waves every 10s
        waveTimer += Time.deltaTime;
        if (waveTimer > 10f)
        {
            waveTimer = 0f;
            EnemyFactory.Instance?.SpawnRandomEnemy();
        }

        // Live health update
        if (PlayerHealth.Instance != null && healthText != null)
            healthText.text = "Health: " + PlayerHealth.Instance.GetCurrentHealth();
    }

    // GEM COLLECT (SFX + "x5")
    public void AddGem()
    {
        gemCount++;
        if (gemTextScore != null)
            gemTextScore.text = "x" + gemCount;  // "x5" gems!

        if (audioManager != null)
            audioManager.Play();  // Gem collect SFX!
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER! Gems Collected: " + gemCount);
        Time.timeScale = 0f;
    }
}