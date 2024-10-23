using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItensInteragir : MonoBehaviour
{
    public GameObject interactionPrompt;
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2.0f;
    private Transform player;
   GameManager gameManager;
    
  
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactionPrompt.SetActive(false);
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= interactionRange)
        {
            interactionPrompt.SetActive(true);
            interactionPrompt.transform.position = transform.position + new Vector3(0, 1.5f, 0);


            if (Input.GetKeyDown(interactionKey))
            {

                Interact();
            }
        }
        else
        {
            interactionPrompt.SetActive(false);
        }

    }

    public void Interact()
    {
       switch (gameObject.tag) 
       {
            case "Item1":
                AmoStatico.item1 = true;
              
                break;

            case "Item2":

                AmoStatico.item2 = true;
             
                break;

            case "Item3":
                AmoStatico.item3 = true;
              
                break;

        }
      

        
    }
    
    
   
}
