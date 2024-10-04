using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JogoDaVelha : MonoBehaviour
{

    [Header("Variaveis")]
    [SerializeField]private int[] _verificação;
    [SerializeField] private int _quemJoga;
    [SerializeField] private bool _xVenceu, _oVenceu;
    public GameObject[] bolas, xzes;
    // Start is called before the first frame update
    void Start()
    {
        _quemJoga = 2;
        Jogar(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jogar(int i)
    {
        _verificação[i] = _quemJoga;
       

        for (int x = 1; x < 3; x++)
        {
      
            if (_verificação[0] == x)
            {
                if (_verificação[1] == x && _verificação[2] == x)
                {   
                    VerificarVencedor(x);
                    


                }
                if (_verificação[3] == x && _verificação[6] == x)
                {
                    VerificarVencedor(x);



                }
                if (_verificação[4] == x && _verificação[8] == x)
                {
                    VerificarVencedor(x);



                }

            }
            else if (_verificação[2] == x)
            {
                if (_verificação[5] == x && _verificação[8] == x)
                {
                    VerificarVencedor(x);



                }else if (_verificação[4] == x && _verificação[6] == x)
                {
                    VerificarVencedor(x);



                }

            }
            else if (_verificação[8] == x)
            {
                if (_verificação[7] == x && _verificação[6] == x)
                {
                    VerificarVencedor(x);



                }

            }
        }
        if (_quemJoga == 2)
        {
            _quemJoga = 3;


        }
        else
        {

            _quemJoga = 2;

        }


    }

    public void VerificarVencedor(int x)
    {
        if(x == 2)
        {
            Vencer("x");

        }
        else
        {

            Vencer("o");

        }


    }
    public void Vencer(string quem)
    {



    }
    public void ColocarXeO()
    {




    }
    
}
