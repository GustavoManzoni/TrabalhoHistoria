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
    public float distanciaDeAtaque, distancia;
    Transform Player;
    public GameObject fumaça;
    Animator animator;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
      
        player = FindObjectOfType<Player>();
        Player = GameObject.FindWithTag("Player").transform;
        distanciaDeAtaque = 7;
        animator  = GameObject.FindWithTag("Player").GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
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

                if (player.podeBater)
                {
                    switch (gameObject.tag)
                    {

                        case "Inim1":
                            if (!AmoStatico.item1)
                            {
                                player.vida--;
                                StartCoroutine(gameManager.TextoAvisoAmuleto());
                            }
                            break;
                        case "Inim2":
                            if (!AmoStatico.item2)
                            {
                                player.vida--;
                                StartCoroutine(gameManager.TextoAvisoAmuleto());
                            }
                            break;

                        case "Inim3":
                            if (!AmoStatico.item3)
                            {
                                player.vida--;
                                StartCoroutine(gameManager.TextoAvisoAmuleto());
                            }
                            break;
                        case "BossFinal":
                            if (!AmoStatico.item3)
                            {
                                player.vida--;
                                StartCoroutine(gameManager.TextoAvisoAmuleto());
                            }
                            break;



                    }

                    vida--;
                    animator.SetTrigger("Atacando");
                    player.TocarSomEspada(
                        );


                    Instantiate(fumaça, transform.position, Quaternion.identity);

                   

                    StartCoroutine(subirEscala());
                    player.podeBater = false;
                    StartCoroutine(player.resetarCooldown());
                    if (vida <= 0)
                    {
                        player.podeBater = true;
                        AmoStatico.levelDoPlayer++;
                        player.atualizarTexto();
                        if (gameObject.tag == "BossFinal")
                        {

                            player.vencer();

                        }
                        Destroy(gameObject);



                    }
                }   
            }
            else
            {
                if (player.podeBater)
                {
                    player.vida--;
                    player.podeBater = false;
                    StartCoroutine(player.resetarCooldown());
                    StartCoroutine(gameManager.TextoAviso());
                    
                }
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
 