using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager2 : MonoBehaviour
{
    public int score = 0;
    public int loseThreshold = -20;
    public AudioSource gameOverSound;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject bucket;
    public TextMeshProUGUI highScoreText;
    private bool isGameOver = false;
    private string scoreKey = "RainScore";
    
    void Start()
    {
        UpdateScoreText();
        int highScore = PlayerPrefs.GetInt("Game2_HighScore", 0);
        if (highScoreText != null)
        highScoreText.text = "HighScore: " + highScore;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    
    // ================ اضافه کردن امتیاز ================
    public void AddScore(int amount)
    {
        if (isGameOver) return;
        
        score += amount;
        UpdateScoreText();
        
        // چک کردن باخت
        if (score <= loseThreshold)
        {
            GameOver();
        }
    }
    
    // ================ به‌روزرسانی متن ================
    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
    
    // ================ Game Over ================
    void GameOver()
    {
        isGameOver = true;
        int currentScore = score;
        int highScore = PlayerPrefs.GetInt("Game2_HighScore", 0);
        if (currentScore > highScore)
        {
         PlayerPrefs.SetInt("Game2_HighScore", currentScore);
         PlayerPrefs.Save();
        if (highScoreText != null)
         highScoreText.text = "HighScore:" + currentScore;}

           // پخش صدای Game Over
       if (gameOverSound != null)
        {
         gameOverSound.Play();
        }
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        // متوقف کردن حرکت سطل
        if (bucket != null)
        {
            bucket.GetComponent<BucketMovement>().enabled = false;
        }
        
        // متوقف کردن تولید قطره
        FindObjectOfType<SimpleSpawner>().enabled = false;
        
        Debug.Log("باختی! امتیازت خیلی کم شد");
    }
    
    // ================ ذخیره ================
    public void SaveGame()
    {
        PlayerPrefs.SetInt(scoreKey, score);
        PlayerPrefs.Save();
        Debug.Log("بازی ذخیره شد! امتیاز: " + score);
    }
    
    // ================ بارگذاری ================
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey(scoreKey))
        {
            score = PlayerPrefs.GetInt(scoreKey);
            UpdateScoreText();
            Debug.Log("بازی بارگذاری شد! امتیاز: " + score);
        }
        else
        {
            Debug.Log("فایل ذخیره‌ای وجود نداره");
        }
    }
    
    // ================ ریست ================
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
{
    SceneManager.LoadScene("MainMenu");
}



}
