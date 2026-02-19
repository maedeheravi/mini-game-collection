using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame1()
    {
        SceneManager.LoadScene("game1");  // اسم صحنه بازی اول
    }
    
    
    public void PlayGame2()
    {
        SceneManager.LoadScene("game2");  // اسم صحنه بازی دوم
    }
    
    
    public void PlayGame3()
    {
        SceneManager.LoadScene("game3.2");  // اسم صحنه بازی سوم
    }
    
    
    public void PlayGame4()
    {
        SceneManager.LoadScene("game4");  // اسم صحنه بازی چهارم
    }
    
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // اسم صحنه منوی اصلی
        Debug.Log("بازگشت به منو");
    }

}
