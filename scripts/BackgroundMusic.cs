using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource;  
    
    void Start()
    {
        if (musicSource != null)
        {
            musicSource.loop = true;  
            musicSource.Play();       
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
