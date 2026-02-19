using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject[] dropPrefabs;  
    public float spawnRate = 1f;      
    public float spawnRangeX = 6f;     
    public float spawnHeight = 5f;     
    
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
        
        if (dropPrefabs.Length == 0)
        {
            Debug.LogError("هیچ قطره‌ای به Spawner وصل نشده!");
            return;
        }
        
        
        int randomIndex = UnityEngine.Random.Range(0, dropPrefabs.Length);
        
        
        float randomX = UnityEngine.Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0);
        
        
        Instantiate(dropPrefabs[randomIndex], spawnPos, Quaternion.identity);
        
        Debug.Log("قطره ساخته شد: " + randomIndex);
    }
}

