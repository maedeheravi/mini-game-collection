using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    public float startForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(2f,3f)*startForce,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
