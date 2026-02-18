using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutManager : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}