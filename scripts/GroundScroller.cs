using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public Transform ground1;
    public Transform ground2;
    public float scrollSpeed = -5f;  // سرعت به چپ (منفی)

    void Update()
    {
        // حرکت هر دو به چپ
        ground1.position += Vector3.right * scrollSpeed * Time.deltaTime;
        ground2.position += Vector3.right * scrollSpeed * Time.deltaTime;

        // اگر Ground1 کامل رفت چپ، ببرش راست
        if (ground1.position.x <= -20f)
        {
            ground1.position = new Vector3(ground2.position.x + 20f, ground1.position.y, 0);
        }

        // همین برای Ground2
        if (ground2.position.x <= -20f)
        {
            ground2.position = new Vector3(ground1.position.x + 20f, ground2.position.y, 0);
        }
    }
}