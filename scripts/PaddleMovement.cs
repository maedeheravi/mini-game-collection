using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed=8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float moveX = Input.GetAxisRaw("Horizontal");
      float moveY = Input.GetAxisRaw("Vertical");
      Vector2 movement = new Vector2(moveX,moveY).normalized;
      rb.velocity = movement*speed;  
    }

    void LateUpdate(){
      float clampedX = Mathf.Clamp(transform.position.x,-5f,5f);
      float clampedY = Mathf.Clamp(transform.position.x,-3f,3f);
      transform.position = new Vector3(clampedX,clampedY,transform.position.z);
    }
}
