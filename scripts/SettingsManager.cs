using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public TextMeshProUGUI musicButtonText;
    public TextMeshProUGUI sfxButtonText;
    
    private bool musicOn = true;
    private bool sfxOn = true;
    
    void Start()
    {
        // خوندن تنظیمات ذخیره شده
        musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        sfxOn = PlayerPrefs.GetInt("SFXOn", 1) == 1;
        
        // به‌روزرسانی متن دکمه‌ها
        UpdateMusicButtonText();
        UpdateSFXButtonText();
        
        // اعمال تنظیمات صدا
        ApplyAudioSettings();
    }
    
    public void ToggleMusic()
    {
        musicOn = !musicOn;
        PlayerPrefs.SetInt("MusicOn", musicOn ? 1 : 0);
        UpdateMusicButtonText();
        ApplyAudioSettings();
    }
    
    public void ToggleSFX()
    {
        sfxOn = !sfxOn;
        PlayerPrefs.SetInt("SFXOn", sfxOn ? 1 : 0);
        UpdateSFXButtonText();
        ApplyAudioSettings();
    }
    
    void UpdateMusicButtonText()
    {
        if (musicButtonText != null)
            musicButtonText.text = musicOn ? "Music: On" : "Music: Off";
    }
    
    void UpdateSFXButtonText()
    {
        if (sfxButtonText != null)
            sfxButtonText.text = sfxOn ? "SFX: ON" : "SFX: Off";
    }
    
    void ApplyAudioSettings()
    {
        // قطع/وصل موسیقی (بک‌گراند)
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
        foreach (GameObject obj in musicObjects)
        {
            AudioSource audio = obj.GetComponent<AudioSource>();
            if (audio != null)
                audio.mute = !musicOn;
        }
        
        // قطع/وصل افکت‌ها
        // میشه با AudioListener هم کنترل کرد
        AudioListener.volume = sfxOn ? 1f : 0f;
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}