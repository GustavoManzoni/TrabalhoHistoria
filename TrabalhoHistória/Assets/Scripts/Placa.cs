using UnityEngine;
using TMPro;
public class Placa : MonoBehaviour
{
   
    public GameObject interactionPrompt, mensagem, mensagem1;
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2.0f;
    private Transform player;

  
    public TMP_Text texto;
    private void Start()
    {
       
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
        if(gameObject.tag == "Placa1")
        {

            mensagem1.SetActive(true);

        }
        else
        {
            mensagem.SetActive(true);

        }
        
    }
    public void Desativar()
    {
        if (gameObject.tag == "Placa1")
        {

            mensagem1.SetActive(false);

        }
        else
        {
            mensagem.SetActive(false);

        }


    }
    
}
