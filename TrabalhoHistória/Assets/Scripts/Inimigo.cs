using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float cooldown; // O tempo de espera entre cada ajuste de escala
    public float escalaMaxima = 1.2f; // O quanto a escala vai aumentar
    public float velocidadeEscala = 0.1f; // A velocidade de crescimento/redução
    public int meuLevel, vida;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (AmoStatico.levelDoPlayer >= meuLevel)
        {
            vida--;
           

        }
        if (vida <= 0)
        {
            Destroy(gameObject);
            AmoStatico.levelDoPlayer++;
            player.atualizarTexto();
        }
        StartCoroutine(subirEscala());
    }

    IEnumerator subirEscala()
    {
        Vector3 escalaOriginal = transform.localScale;
        Vector3 escalaAumentada = escalaOriginal * escalaMaxima;

        // Aumentar escala
        while (transform.localScale.x < escalaAumentada.x)
        {
            transform.localScale += new Vector3(velocidadeEscala, velocidadeEscala, 0);
            yield return new WaitForSeconds(cooldown);
        }

        // Garantir que a escala não passe do limite
        transform.localScale = escalaAumentada;

        // Voltar à escala original
        while (transform.localScale.x > escalaOriginal.x)
        {
            transform.localScale -= new Vector3(velocidadeEscala, velocidadeEscala, 0);
            yield return new WaitForSeconds(cooldown);
        }

        // Garantir que a escala volte ao original
        transform.localScale = escalaOriginal;
    }
}
