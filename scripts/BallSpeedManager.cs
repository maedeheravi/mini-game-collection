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
        
       
        Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
        rb.velocity = randomDir * startingSpeed;
    }
    
    void Update()
    {
        
        if (rb.velocity.magnitude < minSpeed)
        {
            
            rb.velocity = rb.velocity.normalized * minSpeed;
            Debug.Log("سرعت کم بود، زیادش کردم");
        }
        
        
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Paddle")
        {
            
            float randomBoost = Random.Range(0.1f, 0.3f);
            rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + randomBoost);
        }
    }
}


