using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public float velocidade;
    Rigidbody2D rb;
    public TMP_Text exibicaoLevel;
    Animator anim;
    [SerializeField]GameObject avisoPerder;
    bool olhandoDireita = true;
    bool primeiroItem, segundoItem, terceiroItem;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        atualizarTexto();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        if(Input.GetKeyDown(KeyCode.C)) 
        {
            anim.SetBool("Morto", true);
        
        }

    }
    void Movimento()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movimento = new Vector2(horizontal, vertical).normalized;
        rb.velocity = movimento * velocidade;
        if (rb.velocity == Vector2.zero)
        {
            anim.SetBool("Andando", false);

        }
        else
        {
            anim.SetBool("Andando", true);


        }
        
            if (horizontal > 0 && !olhandoDireita || horizontal < 0 && olhandoDireita)
            {
                olhandoDireita = !olhandoDireita;
                Vector2 localscale = transform.localScale;
                localscale.x *= -1;
                transform.localScale = localscale;
            }

        
    }
    public void atualizarTexto()
    {
        exibicaoLevel.text = "Poder de ex�rcito: " + AmoStatico.levelDoPlayer.ToString();


    }
    public void playerMorrer()
    {

        StartCoroutine(PlayerMorrer());

    }
   
    IEnumerator PlayerMorrer()
    {
        anim.SetBool("Morto", true);
        yield return new WaitForSeconds(2);
        avisoPerder.SetActive(true);
        AmoStatico.levelDoPlayer = 0;
        AmoStatico.item3 = false;
        AmoStatico.item2 = false;
        AmoStatico.item3 = false;
    }


}

public static class AmoStatico
{

    public static int levelDoPlayer;
    public static bool item1, item2, item3;

}