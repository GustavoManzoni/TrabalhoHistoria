using UnityEngine;

public class Singletom : MonoBehaviour
{
    public static Singletom Instance; // Instância do singleton
    public AudioSource audioSource; // Fonte de áudio para tocar a música

    private void Awake()
    {
        // Verifica se já existe uma instância
        if (Instance == null)
        {
            Instance = this; // Define esta instância como a única
            DontDestroyOnLoad(gameObject); // Mantém este objeto ao trocar de cena
        }
        else
        {
            Destroy(gameObject); // Destroi a nova instância se já existe uma
        }
    }

    private void Start()
    {
        // Toca a música em loop
        if (audioSource != null)
        {
            audioSource.loop = true; // Define para tocar em loop
            audioSource.Play(); // Inicia a música
        }
        else
        {
            Debug.LogWarning("AudioSource não está atribuído no MusicManager.");
        }
    }
}

