using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;        // Singleton para garantir uma �nica inst�ncia
    public AudioMixer audioMixer;
    public AudioSource backgroundMusic;

    private const string MasterVolumeKey = "MasterVolume";

    void Awake()
    {
        // Implementa��o do Singleton para que exista apenas um AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);      // Preserva este objeto entre cenas
        }
        else
        {
            Destroy(gameObject);               // Destroi inst�ncias duplicadas ao mudar de cena
            return;
        }
    }

    void Start()
    {
        // Configura o volume da m�sica com base nas prefer�ncias salvas
        float masterVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 0.5f);
        audioMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);  // Ajusta o volume do mixer

        // Toca a m�sica de fundo se n�o estiver tocando
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void UpdateMasterVolume(float value)
    {
        // M�todo para atualizar o volume e salvar nas prefer�ncias
        audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);         // Converte para escala de decib�is
        PlayerPrefs.SetFloat(MasterVolumeKey, value);
    }

    public void StopBackgroundMusic()
    {
        // M�todo para parar a m�sica de fundo, caso precise parar manualmente
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }
}
