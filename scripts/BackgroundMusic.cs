using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource;  // منبع موزیک
    
    void Start()
    {
        if (musicSource != null)
        {
            musicSource.loop = true;  // تکرار کن
            musicSource.Play();        // پخش کن
        }
    }
    
    public void StopMusic()
    {
        if (musicSource != null)
            musicSource.Stop();
    }
    
    public void SetVolume(float volume)
    {
        if (musicSource != null)
            musicSource.volume = volume;
    }
}