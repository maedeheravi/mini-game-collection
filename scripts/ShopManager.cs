using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coins = 5000;  // سکه اولیه (بعداً از PlayerPrefs بخون)
    
    void Start()
    {
        // اینجا می‌تونی سکه رو از ذخیره‌سازی بخونی
        UpdateCoinText();
    }
    
    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coins;
    }
    
    public void BuyItem(int price)
    {
        if (coins >= price)
        {
            coins -= price;
            UpdateCoinText();
            Debug.Log("Purchese Successfull!");
            // اینجا می‌تونی آیتم رو ذخیره کنی
        }
        else
        {
            Debug.Log("Not Enough Coins!");
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}