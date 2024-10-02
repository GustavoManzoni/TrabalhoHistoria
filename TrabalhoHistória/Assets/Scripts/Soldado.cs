using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldado : MonoBehaviour
{
    public Transform player;  // Refer�ncia ao jogador
    public float velocidade = 2f;  // Velocidade de movimento do soldado
    public float distanciaMinima = 1.5f;  // Dist�ncia m�nima para parar de seguir o jogador
    public float distanciaEntreSoldados = 1f;  // Dist�ncia m�nima entre soldados

    void Start()
    {
        // Encontra o jogador no in�cio do jogo (assumindo que o jogador tem a tag "Player")
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Verifica a dist�ncia entre o soldado e o jogador
        float distancia = Vector2.Distance(transform.position, player.position);

        // Se a dist�ncia for maior que a m�nima, o soldado se move em dire��o ao jogador
        if (distancia > distanciaMinima)
        {
            // Movimento suave em dire��o ao jogador
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidade * Time.deltaTime);
        }

        // Evita que o soldado encoste em outros soldados
       
    }

    void EvitarEncostarEmOutrosSoldados()
    {
        // Obt�m todos os soldados na cena
        GameObject[] soldados = GameObject.FindGameObjectsWithTag("Soldado");

        foreach (GameObject soldado in soldados)
        {
            
            if (soldado != this.gameObject)
            {
                
                float distanciaEntreEles = Vector2.Distance(transform.position, soldado.transform.position);

              
                if (distanciaEntreEles < distanciaEntreSoldados)
                {
                   
                    Vector2 direcaoFuga = (transform.position - soldado.transform.position).normalized;
                    transform.position += (Vector3)(direcaoFuga * velocidade * Time.deltaTime);
                }
            }
        }
    }
}
