using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BucketMovement : MonoBehaviour
{
    public float speed = 8f;
    private float minX = -10.4f;
    private float maxX = 10.4f;
    
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX * speed * Time.deltaTime, 0, 0);
        
        // محدود کردن حرکت
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}

