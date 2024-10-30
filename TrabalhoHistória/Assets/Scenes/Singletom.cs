using UnityEngine;
using UnityEngine.UI;

public class Singletom : MonoBehaviour
{
    public AudioSource audioSource; 
    public Slider volumeSlider;
    private void Start()
    {
       
      
            audioSource.loop = true;
           audioSource.Play();
        
        
       
            volumeSlider.onValueChanged.AddListener(AdjustVolume);
            volumeSlider.value = audioSource.volume;    
    }

    private void AdjustVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
