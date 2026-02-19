using UnityEngine;

public class GameOverOnRed : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioSource audioSource; 

    void Start()
    {
        
        scoreManager = FindObjectOfType<ScoreManager>();
        
        
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
            
            if (audioSource != null)
            {
                audioSource.Play();
            }

           
            if (scoreManager != null)
            {
                scoreManager.OnRedWallHit();
            }

            
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                ballRb.velocity = ballRb.velocity.normalized * 3f;
            }
        }
    }

}
