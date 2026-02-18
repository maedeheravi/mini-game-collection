using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSimple : MonoBehaviour
{
  
    public float speed = 5f;
    public AudioSource hitSound;


    void Update()
    {
        // حرکت با کلیدهای جهت
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            Debug.Log("بالا میره");
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            Debug.Log("پایین میره");
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        
        // محدود کردن حرکت
        float clampedX = Mathf.Clamp(transform.position.x, -4.5f, 4.5f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.25f, 4.25f);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

      void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (hitSound != null)
                hitSound.Play();
        }
    }
}



    

