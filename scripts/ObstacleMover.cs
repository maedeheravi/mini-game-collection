using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left * GameManager.instance.gameSpeed * Time.deltaTime);
        if (transform.position.x < -30f) // خارج از صفحه → حذف
            Destroy(gameObject);
    }
}