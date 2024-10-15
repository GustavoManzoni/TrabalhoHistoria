using UnityEngine;

public class Placa : MonoBehaviour
{
   
    public GameObject interactionPrompt, mensagem;
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2.0f;
    private Transform player;
    
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
        mensagem.SetActive(true);
    }
    public void Desativar()
    {
        mensagem.SetActive(true);


    }
    
}
