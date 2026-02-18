using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // رفتن به بازی اول
    public void PlayGame1()
    {
        SceneManager.LoadScene("game1");  // اسم صحنه بازی اول
    }
    
    // رفتن به بازی دوم
    public void PlayGame2()
    {
        SceneManager.LoadScene("game2");  // اسم صحنه بازی دوم
    }
    
    // رفتن به بازی سوم
    public void PlayGame3()
    {
        SceneManager.LoadScene("game3.2");  // اسم صحنه بازی سوم
    }
    
    // رفتن به بازی چهارم
    public void PlayGame4()
    {
        SceneManager.LoadScene("game4");  // اسم صحنه بازی چهارم
    }
    
    // برگشت به منوی اصلی
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // اسم صحنه منوی اصلی
        Debug.Log("بازگشت به منو");
    }
}