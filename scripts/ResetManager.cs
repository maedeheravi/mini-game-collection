using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour
{
    // این تابع برای دکمه ریست
    public void ResetGame()
    {
        // اسم صحنه فعلی رو بگیر و دوباره لودش کن
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        
        Debug.Log("بازی ریست شد! صحنه: " + currentSceneName);
    }
    
    // این تابع برای ریست با اسم صحنه (اگه خواستی)
    public void ResetToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
