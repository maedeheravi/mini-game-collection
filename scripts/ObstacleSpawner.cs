using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] cactusPrefabs;  // آرایه‌ای از کاکتوس‌ها
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public float spawnX = 8f;
    public float spawnY = -2.5f;
    
    void Start()
    {
        // شروع تولید کاکتوس
        Invoke("SpawnCactus", Random.Range(minSpawnTime, maxSpawnTime));
    }
    
    void SpawnCactus()
    {
        // اگه کاکتوسی تعریف نشده، خطا بده
        if (cactusPrefabs.Length == 0)
        {
            Debug.LogError("هیچ کاکتوسی به Spawner وصل نشده!");
            return;
        }
        
        // انتخاب تصادفی یکی از کاکتوس‌ها
        int randomIndex = Random.Range(0, cactusPrefabs.Length);
        
        // ساختن کاکتوس
        Instantiate(cactusPrefabs[randomIndex], new Vector3(spawnX, spawnY, 0), Quaternion.identity);
        
        // برنامه‌ریزی برای کاکتوس بعدی
        Invoke("SpawnCactus", Random.Range(minSpawnTime, maxSpawnTime));
    }
    
    public void StopSpawning()
    {
        CancelInvoke();  // متوقف کردن تولید (وقتی Game Over)
    }
}