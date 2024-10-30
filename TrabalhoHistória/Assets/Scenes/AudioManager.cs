using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;        // Singleton para garantir uma única instância
    public AudioMixer audioMixer;
    public AudioSource backgroundMusic;

    private const string MasterVolumeKey = "MasterVolume";

    void Awake()
    {
        // Implementação do Singleton para que exista apenas um AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);      // Preserva este objeto entre cenas
        }
        else
        {
            Destroy(gameObject);               // Destroi instâncias duplicadas ao mudar de cena
            return;
        }
    }

    void Start()
    {
        // Configura o volume da música com base nas preferências salvas
        float masterVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 0.5f);
        audioMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);  // Ajusta o volume do mixer

        // Toca a música de fundo se não estiver tocando
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void UpdateMasterVolume(float value)
    {
        // Método para atualizar o volume e salvar nas preferências
        audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);         // Converte para escala de decibéis
        PlayerPrefs.SetFloat(MasterVolumeKey, value);
    }

    public void StopBackgroundMusic()
    {
        // Método para parar a música de fundo, caso precise parar manualmente
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }
}
