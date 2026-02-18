using UnityEngine;

public class GameOverOnRed : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioSource audioSource;  // برای صدا

    void Start()
    {
        // پیدا کردن ScoreManager
        scoreManager = FindObjectOfType<ScoreManager>();
        
        // گرفتن Audio Source از روی خود دیوار
        audioSource = GetComponent<AudioSource>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager پیدا نشد! مطمئن شو توی صحنه هست");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // پخش صدا (اگه Audio Source داشته باشه)
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // به ScoreManager خبر بده
            if (scoreManager != null)
            {
                scoreManager.OnRedWallHit();
            }

            // یه کم توپ رو برگردون (اختیاری)
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                ballRb.velocity = ballRb.velocity.normalized * 3f;
            }
        }
    }
}