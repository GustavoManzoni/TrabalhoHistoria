using UnityEngine;
using UnityEngine.UI;

public class Singletom : MonoBehaviour
{
    public static Singletom Instance; // Instância do singleton
    public AudioSource audioSource; // Fonte de áudio para tocar a música
    public Slider volumeSlider; 

    private void Awake()
    {
     
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
            return;
        }
    }

    private void Start()
    {
       
        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource não está atribuído no MusicManager.");
        }

      
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(AdjustVolume);
            volumeSlider.value = audioSource.volume; 
        }
    }

    private void AdjustVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
