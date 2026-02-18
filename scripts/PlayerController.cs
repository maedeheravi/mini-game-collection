using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 12f;           // می‌تونی این عدد رو توی Inspector تغییر بدی
    private Rigidbody2D rb;
    private Animator animator;              // اگر انیمیشن اضافه کردی
    private bool isGrounded = true;
    public AudioClip jumpClip;
    public AudioClip jumpSound;  // این رو به کلاس اضافه کن
    private AudioSource audioSource;  // این رو هم اضافه کن

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    // اگر Animator نداری، این خط رو کامنت کن
    }

    void Update()
    {
        // پرش فقط وقتی روی زمین هستیم
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            

            audioSource = GetComponent<AudioSource>();  // این خط رو اضافه کن

            if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
            Debug.Log("🎵 صدای جامپ پخش شد");
        }
        else
        {
            Debug.LogError("❌ audioSource یا jumpSound خالیه!");
        }

            // اگر انیمیشن داری:
            if (animator != null)
            {
                animator.SetBool("IsJumping", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
{
    // ... کد پرش
    GetComponent<AudioSource>().PlayOneShot(jumpClip);  // public AudioClip jumpClip; اضافه کن
}
    }

    // وقتی با چیزی برخورد می‌کنیم
    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Obstacle"))
    {
        Debug.Log("💥 برخورد فیزیکی با کاکتوس!");
        GameManager.instance.GameOver();
    }
}

    // اختیاری: برای زمین‌های نازک گاهی بهتر کار می‌کنه
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
{
    // اگه به کاکتوس خورد
    if (other.CompareTag("Obstacle"))
    {
        Debug.Log("به کاکتوس خوردم!");
        
        
        
    }
}
}