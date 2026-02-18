using UnityEngine;
using UnityEngine.UI; // برای UI
using UnityEngine.SceneManagement; // برای Restart

public class GameManager : MonoBehaviour
{
    public Transform spawnPointGround;
    public Transform spawnPointAir; 
    public AudioClip hitClip;
    public static GameManager instance; // Singleton
    public AudioClip gameOverSound;  // صدای Game Over
    private AudioSource audioSource;  // AudioSource

    public float gameSpeed = 5f; // سرعت اولیه
    public Text scoreText; // UI Text برای امتیاز
    public GameObject gameOverPanel; // پنل Game Over (بعداً می‌سازیم)

    private float score = 0f;

    public Text highScoreText;
    public GameObject[] obstaclePrefabs; // آرایه prefabها (کاکتوس، پرنده)
    private float nextSpawnTime = 0f;  // اضافه کن بالای کلاس

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

  
void Update()
{
    // افزایش سرعت
    gameSpeed += Time.deltaTime * 0.01f;

    // امتیاز
    score += Time.deltaTime * gameSpeed * 0.1f;
    if (scoreText != null)
        scoreText.text = ((int)score).ToString("00000");

    // اسپاون یکی یکی با Timer (جایگزین Random قدیمی)
    if (Time.time > nextSpawnTime)
    {
        SpawnObstacle();
        nextSpawnTime = Time.time + Random.Range(1.8f, 3.2f);  // فاصله ۱.۸–۳.۲ ثانیه (تست کن)
    }
    // Hi-Score (اضافه کن)
int highScore = PlayerPrefs.GetInt("HighScore", 0);
if ((int)score > highScore)
{
    PlayerPrefs.SetInt("HighScore", (int)score);
    highScore = (int)score;
}

if (highScoreText != null)
    highScoreText.text = "HI " + highScore.ToString("00000");
}
    void SpawnObstacle()
{
    if (obstaclePrefabs.Length == 0) return;  // فیکس: اگر خالی، اسپاون نکن

    int randomIndex = Random.Range(0, obstaclePrefabs.Length);
    
    Vector3 spawnPos;
    if (obstaclePrefabs[randomIndex].name.Contains("Bird"))
    {
        spawnPos = spawnPointAir.position;
    }
    else
    {
        spawnPos = spawnPointGround.position;
    }
    
    GameObject obstacle = Instantiate(obstaclePrefabs[randomIndex], spawnPos, Quaternion.identity);

    GetComponent<AudioSource>().PlayOneShot(hitClip);  

    if (score > 700)
{
    float nightFactor = Mathf.Clamp01((score - 700) / 300f);
    Camera.main.backgroundColor = Color.Lerp(Color.white, new Color(0.05f, 0.05f, 0.2f), nightFactor);
}

}
 public void GameOver()
{
    
    Debug.Log("GAME OVER CALLED!");
    
     if (audioSource != null && gameOverSound != null)
    {
        audioSource.PlayOneShot(gameOverSound);
        Debug.Log("🎵 صدای Game Over پخش شد");
    }

    Time.timeScale = 0f;  // بازی رو متوقف کن
    
    if (gameOverPanel != null)
    {
        gameOverPanel.SetActive(true);
        Debug.Log("پنل فعال شد");
    }
    else
    {
        Debug.LogError("gameOverPanel NULL!");
    }
}

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
{
    SceneManager.LoadScene("MainMenu");
}
}