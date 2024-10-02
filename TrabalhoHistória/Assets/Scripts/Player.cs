    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class Player : MonoBehaviour
    {
        public float velocidade;
        Rigidbody2D rb;
        public TMP_Text exibicaoLevel;
    Animator anim;
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
        
        }
        void Movimento()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 movimento = new Vector2(horizontal, vertical).normalized;
            rb.velocity = movimento * velocidade;
            if(rb.velocity == Vector2.zero) 
            {
               anim.SetBool("Andando", false);

        }
            else
            {
               anim.SetBool("Andando", true);


            }
        }
        public void atualizarTexto()
        {
            exibicaoLevel.text = "Poder de exército: " + AmoStatico.levelDoPlayer.ToString();


        }
    }
    public static class AmoStatico
    {

        public static int levelDoPlayer;

    }
