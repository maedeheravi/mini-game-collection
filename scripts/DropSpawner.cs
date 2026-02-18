using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject[] dropPrefabs;  // انواع قطره‌ها
    public float spawnRate = 1f;      // هر چند ثانیه یکی
    public float spawnRangeX = 6f;     // محدوده افقی
    public float spawnHeight = 5f;     // ارتفاع تولید
    
    private float timer = 0f;
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawnRate)
        {
            SpawnDrop();
            timer = 0f;
        }
    }
    
    void SpawnDrop()
    {
        // اگه قطره‌ای تعریف نشده
        if (dropPrefabs.Length == 0)
        {
            Debug.LogError("هیچ قطره‌ای به Spawner وصل نشده!");
            return;
        }
        
        // انتخاب تصادفی بین قطره‌ها (آبی یا قرمز)
        int randomIndex = UnityEngine.Random.Range(0, dropPrefabs.Length);
        
        // موقعیت تصادفی
        float randomX = UnityEngine.Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0);
        
        // ساختن قطره
        Instantiate(dropPrefabs[randomIndex], spawnPos, Quaternion.identity);
        
        Debug.Log("قطره ساخته شد: " + randomIndex);
    }
}
