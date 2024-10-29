using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float velocidade;
    Rigidbody2D rb;
    public TMP_Text exibicaoLevel;
    Animator anim;
    [SerializeField]GameObject avisoPerder, preto;
    bool olhandoDireita = true;
    public int vida;
    public GameObject[] playerVida;
    public bool podeBater;
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        atualizarTexto();
        anim = GetComponent<Animator>();
        vida = 3;
        podeBater = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
       switch (vida) 
       {
            case 0:
                playerVida[0].SetActive(false);
                playerMorrer();
                AmoStatico.levelDoPlayer = 0;
                AmoStatico.item3 = false;
                AmoStatico.item2 = false;
                AmoStatico.item3 = false;
                break;
            case 1:
                playerVida[1].SetActive(false);
                break;

            case 2:
                playerVida[2].SetActive(false);
                break;

           



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
    public IEnumerator resetarCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        podeBater = true;

    }
    public void atualizarTexto()
    {
        exibicaoLevel.text = "Poder de exército: " + AmoStatico.levelDoPlayer.ToString();


    }
    public void playerMorrer()
    {

        StartCoroutine(PlayerMorrer());
        preto.SetActive(true);
    }
   
    IEnumerator PlayerMorrer()
    {
       
        
        yield return new WaitForSeconds(2);
        AmoStatico.levelDoPlayer = 0;
        AmoStatico.item3 = false;
        AmoStatico.item2 = false;
        AmoStatico.item3 = false;
    }
    public void bobo()
    {
        bobo();
    }
    public void vencer()
    {
        preto.tag = "Untagged";
        preto.SetActive (true);
        Invoke("trocar", 2.5f);
    }
    public void trocar()
    {
        SceneManager.LoadScene("cutscene");


    }

}

public static class AmoStatico
{

    public static int levelDoPlayer;
    public static bool item1, item2, item3;

}