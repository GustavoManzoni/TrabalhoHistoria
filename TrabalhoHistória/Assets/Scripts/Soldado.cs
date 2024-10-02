using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldado : MonoBehaviour
{
    public Transform player;  // Referência ao jogador
    public float velocidade = 2f;  // Velocidade de movimento do soldado
    public float distanciaMinima = 1.5f;  // Distância mínima para parar de seguir o jogador
    public float distanciaEntreSoldados = 1f;  // Distância mínima entre soldados

    void Start()
    {
        // Encontra o jogador no início do jogo (assumindo que o jogador tem a tag "Player")
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Verifica a distância entre o soldado e o jogador
        float distancia = Vector2.Distance(transform.position, player.position);

        // Se a distância for maior que a mínima, o soldado se move em direção ao jogador
        if (distancia > distanciaMinima)
        {
            // Movimento suave em direção ao jogador
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidade * Time.deltaTime);
        }

        // Evita que o soldado encoste em outros soldados
       
    }

    void EvitarEncostarEmOutrosSoldados()
    {
        // Obtém todos os soldados na cena
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
