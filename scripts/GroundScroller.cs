using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public Transform ground1;
    public Transform ground2;
    public float scrollSpeed = -5f;  

    void Update()
    {
        
        ground1.position += Vector3.right * scrollSpeed * Time.deltaTime;
        ground2.position += Vector3.right * scrollSpeed * Time.deltaTime;

        
        if (ground1.position.x <= -20f)
        {
            ground1.position = new Vector3(ground2.position.x + 20f, ground1.position.y, 0);
        }

         
        if (ground2.position.x <= -20f)
        {
            ground2.position = new Vector3(ground1.position.x + 20f, ground2.position.y, 0);
        }
    }

}
