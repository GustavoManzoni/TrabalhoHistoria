using UnityEngine;

public class Singletom : MonoBehaviour
{
    public static Singletom Instance; // Inst�ncia do singleton
    public AudioSource audioSource; // Fonte de �udio para tocar a m�sica

    private void Awake()
    {
        // Verifica se j� existe uma inst�ncia
        if (Instance == null)
        {
            Instance = this; // Define esta inst�ncia como a �nica
            DontDestroyOnLoad(gameObject); // Mant�m este objeto ao trocar de cena
        }
        else
        {
            Destroy(gameObject); // Destroi a nova inst�ncia se j� existe uma
        }
    }

    private void Start()
    {
        // Toca a m�sica em loop
        if (audioSource != null)
        {
            audioSource.loop = true; // Define para tocar em loop
            audioSource.Play(); // Inicia a m�sica
        }
        else
        {
            Debug.LogWarning("AudioSource n�o est� atribu�do no MusicManager.");
        }
    }
}

