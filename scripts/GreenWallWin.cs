using UnityEngine;

public class GreenWallWin : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioSource collectSound; 

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
                if (collectSound != null) 
                {
                    collectSound.Play(); 
                }
                Debug.Log("به دیوار سبز خورد! +۱۰ امتیاز");
            }
        }
    }

}
