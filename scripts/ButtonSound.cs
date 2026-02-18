using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonClickSound;  // صدای کلیک
    
    public void PlayClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
            Debug.Log("صدای دکمه پخش شد");
        }
    }
}