using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDropScript : MonoBehaviour
{
    public int pointValue = 10;
    public bool isBad = false;
    public AudioSource collectSound;
    private ScoreManager2 scoreManager;
    
    void Start()
    {
        // پیدا کردن ScoreManager2 توی صحنه
        scoreManager = FindObjectOfType<ScoreManager2>();
        
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager2 پیدا نشد! مطمئن شو توی صحنه هست");
        }
        
        // اگه قطره بد بود، امتیاز منفی بده
        if (isBad)
        {
            pointValue = -15;
        }
        
        // اگه به زمین نرسید، بعد ۵ ثانیه خودش نابود شه
        Destroy(gameObject, 5f);
    }
    
    // وقتی با چیزی که Trigger داره برخورد می‌کنه
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("برخورد اتفاق افتاد با"+other.name);
        // اگه به سطل خورد
        if (other.CompareTag("Bucket"))
        {
            if(collectSound!=null)
            {
                collectSound.Play();
            }

            Debug.Log("قطره به سطل خورد! امتیاز: " + pointValue);
            
            // به ScoreManager امتیاز بده
            if (scoreManager != null)
            {
                scoreManager.AddScore(pointValue);
            }
            
            // قطره رو نابود کن
            Destroy(gameObject);
        }
    }
    
    // وقتی با چیزی که Collider معمولی داره برخورد می‌کنه
    void OnCollisionEnter2D(Collision2D collision)
    {
        // اگه به زمین خورد
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}