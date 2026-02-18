using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float splashTime = 3f;  // ۳ ثانیه
    
    void Start()
    {
        // بعد از splashTime ثانیه برو به صحنه MainMenu
        Invoke("LoadMainMenu", splashTime);
    }
    
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}