using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject goodDrop;    // قطره آبی
    public GameObject badDrop;     // قطره قرمز
    public float spawnRate = 1f;
    public float spawnRange = 5f;
    public float spawnHeight = 5f;
    
    void Start()
    {
        // هر ثانیه یه بار صدا بزن
        InvokeRepeating("SpawnDrop", 1f, spawnRate);
    }
    
    void SpawnDrop()
    {
        // انتخاب بین قطره خوب و بد (۵۰٪ - ۵۰٪)
        int random = UnityEngine.Random.Range(0, 2);  // 0 یا 1
        
        GameObject dropToSpawn;
        
        if (random == 0)
        {
            dropToSpawn = goodDrop;
            Debug.Log("قطره آبی میاد");
        }
        else
        {
            dropToSpawn = badDrop;
            Debug.Log("قطره قرمز میاد");
        }
        
        // اگه قطره‌ای وصل نشده بود
        if (dropToSpawn == null)
        {
            Debug.LogError("قطره به Spawner وصل نیست!");
            return;
        }
        
        // موقعیت تصادفی
        float randomX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0);
        
        // ساختن قطره
        Instantiate(dropToSpawn, spawnPos, Quaternion.identity);
    }
}
