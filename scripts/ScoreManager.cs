using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score = 50;
    public int penalty = 10;
    public TextMeshProUGUI highScoreText;  // متن نمایش رکورد داخل بازی
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    
    public GameObject ball;
    public GameObject paddle;
    public AudioSource gameOverSound;
    private bool isGameOver = false;
    private Rigidbody2D ballRb;
    
    // کلیدهای ذخیره سازی
    private string scoreKey = "PlayerScore";
    private string ballPosXKey = "BallPosX";
    private string ballPosYKey = "BallPosY";
    private string ballVelXKey = "BallVelX";
    private string ballVelYKey = "BallVelY";
    private string paddlePosXKey = "PaddlePosX";
    private string paddlePosYKey = "PaddlePosY";
    
    void Start()
    {

        int highScore = PlayerPrefs.GetInt("Game1_HighScore", 0);
        if (highScoreText != null)
           highScoreText.text = "HighScore: " + highScore;

        if (ball != null)
            ballRb = ball.GetComponent<Rigidbody2D>();
            
        UpdateScoreText();
        
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }
    
    // ================ تابع ذخیره ================
    public void SaveGame()
    {
        // ذخیره امتیاز
        PlayerPrefs.SetInt(scoreKey, score);
        
        // ذخیره موقعیت توپ
        PlayerPrefs.SetFloat(ballPosXKey, ball.transform.position.x);
        PlayerPrefs.SetFloat(ballPosYKey, ball.transform.position.y);
        
        // ذخیره سرعت توپ
        PlayerPrefs.SetFloat(ballVelXKey, ballRb.velocity.x);
        PlayerPrefs.SetFloat(ballVelYKey, ballRb.velocity.y);
        
        // ذخیره موقعیت پدل
        PlayerPrefs.SetFloat(paddlePosXKey, paddle.transform.position.x);
        PlayerPrefs.SetFloat(paddlePosYKey, paddle.transform.position.y);
        
        // نهایی کردن ذخیره
        PlayerPrefs.Save();
        
        Debug.Log("بازی ذخیره شد! امتیاز: " + score);
    }
    
    // ================ تابع بارگذاری ================
    public void LoadGame()
    {
        // چک کن که قبلاً ذخیره‌ای وجود داره
        if (PlayerPrefs.HasKey(scoreKey))
        {
            // بارگذاری امتیاز
            score = PlayerPrefs.GetInt(scoreKey);
            
            // بارگذاری موقعیت توپ
            float ballX = PlayerPrefs.GetFloat(ballPosXKey);
            float ballY = PlayerPrefs.GetFloat(ballPosYKey);
            ball.transform.position = new Vector3(ballX, ballY, 0);
            
            // بارگذاری سرعت توپ
            float velX = PlayerPrefs.GetFloat(ballVelXKey);
            float velY = PlayerPrefs.GetFloat(ballVelYKey);
            ballRb.velocity = new Vector2(velX, velY);
            
            // بارگذاری موقعیت پدل
            float paddleX = PlayerPrefs.GetFloat(paddlePosXKey);
            float paddleY = PlayerPrefs.GetFloat(paddlePosYKey);
            paddle.transform.position = new Vector3(paddleX, paddleY, 0);
            
            // به‌روزرسانی متن
            UpdateScoreText();
            
            // اگه Game Over بود، برش گردون
            isGameOver = false;
            if (gameOverText != null)
                gameOverText.gameObject.SetActive(false);
            
            // فعال کردن حرکت پدل
            if (paddle != null)
            {
                var movementScript = paddle.GetComponent<PaddleSimple>() 
                                   ?? paddle.GetComponent<PaddleMovement>()
                                   as MonoBehaviour;
                
                if (movementScript != null)
                    movementScript.enabled = true;
            }
            
            Debug.Log("بازی بارگذاری شد! امتیاز: " + score);
        }
        else
        {
            Debug.Log("فایل ذخیره‌ای وجود نداره");
        }
    }
    
    // ================ تابع ریست (پاک کردن ذخیره) ================
    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("همه ذخیره‌ها پاک شدن");
    }
    
    public void OnRedWallHit()
    {
        if (isGameOver) return;
        
        score -= penalty;
        UpdateScoreText();
        
        if (score <= 0)
        {
            GameOver();
        }
    }
    
    void UpdateScoreText()
    {
 
       if (scoreText != null)
            scoreText.text = "Score: " + Mathf.Max(0, score);
    }
    
    void GameOver()
    {
        isGameOver = true;
         int currentScore = score;  // امتیاز فعلی
         int highScore = PlayerPrefs.GetInt("Game1_HighScore", 0);
    
         if (currentScore > highScore)
        {
        PlayerPrefs.SetInt("Game1_HighScore", currentScore);
        PlayerPrefs.Save();
        
        // به‌روزرسانی متن داخل بازی (اگه بازی هنوز تموم نشده)
        if (highScoreText != null)
        {
            highScoreText.text = "HightScore: " + currentScore;
        }
        
        Debug.Log("new Record!: " + currentScore);
        }
        

        // پخش صدای Game Over
       if (gameOverSound != null)
        {
         gameOverSound.Play();
        }
        
        
        if (gameOverText != null)
        {
            gameOverText.text = "GAME OVER\nYou Lost!";
            gameOverText.gameObject.SetActive(true);
        }
        
        if (ballRb != null)
            ballRb.velocity = Vector2.zero;
        
        if (paddle != null)
        {
            var movementScript = paddle.GetComponent<PaddleSimple>() 
                               ?? paddle.GetComponent<PaddleMovement>()
                              as MonoBehaviour;
            
            if (movementScript != null)
                movementScript.enabled = false;
        }
    }

    public void ResetGame()
{
    // بارگذاری مجدد صحنه فعلی
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

public void AddScore(int amount)
{
    if (isGameOver) return;
    
    score += amount;
    UpdateScoreText();
    
    // اگه خواستی چک کنی امتیاز از حدی کمتر نشه
    if (score <= 0)
    {
        GameOver();
    }
}

public void BackToMenu()
{
    SceneManager.LoadScene("MainMenu");
}

}