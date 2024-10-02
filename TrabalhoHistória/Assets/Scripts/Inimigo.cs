using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float cooldown; // O tempo de espera entre cada ajuste de escala
    public float escalaMaxima = 1.2f; // O quanto a escala vai aumentar
    public float velocidadeEscala = 0.1f; // A velocidade de crescimento/redu��o
    public int meuLevel, vida;
    Player player;
    public float distanciaDeAtaque, distancia;
    Transform Player;
    public GameObject fuma�a;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0.0005f;
        velocidadeEscala = 0.01f;
        player = FindObjectOfType<Player>();
        Player = GameObject.FindWithTag("Player").transform;
        distanciaDeAtaque = 7;
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(transform.position, player.transform.position);
    }

    private void OnMouseDown()
    {
        if (distancia < distanciaDeAtaque)
        {
            if (AmoStatico.levelDoPlayer >= meuLevel)
            {
                vida--;

                // Obtendo a posi��o do mouse em coordenadas do mundo
                Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Instanciar a fuma�a na posi��o do mouse
                Instantiate(fuma�a, posicaoMouse, Quaternion.identity);

                // Verifica se o inimigo foi derrotado
                if (vida <= 0)
                {
                    Destroy(gameObject);
                    AmoStatico.levelDoPlayer++;
                    player.atualizarTexto();
                }

                StartCoroutine(subirEscala());
            }
        }
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

        // Garantir que a escala n�o passe do limite
        transform.localScale = escalaAumentada;

        // Voltar � escala original
        while (transform.localScale.x > escalaOriginal.x)
        {
            transform.localScale -= new Vector3(velocidadeEscala, velocidadeEscala, 0);
            yield return new WaitForSeconds(cooldown);
        }

        // Garantir que a escala volte ao original
        transform.localScale = escalaOriginal;
    }
}
 