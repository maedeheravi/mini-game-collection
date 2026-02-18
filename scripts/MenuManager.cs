using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // دکمه استارت - می‌ره به صفحه انتخاب بازی
    public void StartGame()
    {
        SceneManager.LoadScene("Start");  // صفحه‌ای که ۳ تا بازی توش هست
    }
    
    // دکمه تنظیمات
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    
    // دکمه فروشگاه
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }
    
    // دکمه درباره ما
    public void OpenAbout()
    {
        SceneManager.LoadScene("About");
    }
    
    // دکمه خروج
    public void QuitGame()
    {
        Application.Quit();
        
        // برای تست توی خود یونیتی
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}