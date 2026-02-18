using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedManager : MonoBehaviour
{
  

    private Rigidbody2D rb;
    public float minSpeed = 3f;
    public float maxSpeed = 7f;
    public float startingSpeed = 5f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // سرعت اولیه
        Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
        rb.velocity = randomDir * startingSpeed;
    }
    
    void Update()
    {
        // اگه سرعت کم شد، زیادش کن
        if (rb.velocity.magnitude < minSpeed)
        {
            // حفظ جهت ولی افزایش سرعت
            rb.velocity = rb.velocity.normalized * minSpeed;
            Debug.Log("سرعت کم بود، زیادش کردم");
        }
        
        // اگه سرعت زیاد شد، کمش کن (اختیاری)
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // یه کم تنوع به برخوردها بده
        if (collision.gameObject.name == "Paddle")
        {
            // یه نیروی کوچیک اضافه کن
            float randomBoost = Random.Range(0.1f, 0.3f);
            rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + randomBoost);
        }
    }
}

