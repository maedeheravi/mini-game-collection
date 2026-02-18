using UnityEngine;

public class GreenWallWin : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioSource collectSound; // <--- این خط رو برای صدا اضافه کن

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);
                if (collectSound != null) // <--- اگه صدا وجود داشت
                {
                    collectSound.Play(); // <--- پخشش کن
                }
                Debug.Log("به دیوار سبز خورد! +۱۰ امتیاز");
            }
        }
    }
}