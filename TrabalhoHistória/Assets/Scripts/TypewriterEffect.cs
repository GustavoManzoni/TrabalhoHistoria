using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text uiText;  // O texto que vai aparecer
    public float typingSpeed = 0.05f;  // Velocidade da escrita

    private string baseText;  // Texto base que ser� exibido
    private Coroutine typingCoroutine;  // Refer�ncia � corrotina
    public GameObject aa;

    void Awake()
    {
        // Inicializa o texto base, garantindo que ele seja mantido
        baseText = uiText.text;  // Pega o texto completo
        uiText.text = "";  // Limpa o texto exibido inicialmente
    }

    private void OnEnable()
    {
        RestartTyping();  // Reinicia o efeito quando o objeto � ativado
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            aa.SetActive(false);
        }
    }

    // M�todo para reiniciar o efeito de digita��o
    public void RestartTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);  // Para a corrotina anterior se estiver ativa
        }
        uiText.text = "";  // Limpa o texto exibido
        typingCoroutine = StartCoroutine(ShowText());  // Inicia a corrotina
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < baseText.Length; i++)
        {
            uiText.text += baseText[i];  // Adiciona uma letra ao texto atual
            yield return new WaitForSeconds(typingSpeed);  // Intervalo entre cada letra
        }
    }
}
