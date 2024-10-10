using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogoDaVelha : MonoBehaviour
{

    [Header("Variaveis")]
    [SerializeField] private int[] _verifica��o = new int[9];
    [SerializeField] private int _quemJoga;
    [SerializeField] private bool _xVenceu, _oVenceu;
    public GameObject[] bolas, xzes;
    // Start is called before the first frame update
    void Start()
    {
        _quemJoga = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ColocarXeO(int i)
    {
        if (_quemJoga == 2)
        {
            xzes[i].SetActive(true);


        }
        else
        {
            bolas[i].SetActive(true);


        }
        


    }
    public void Jogar(int i)
    {
        _verifica��o[i] = _quemJoga;
        ColocarXeO(i);

        for (int x = 2; x < 4; x++)
        {

            if (_verifica��o[0] == x)
            {
                if (_verifica��o[1] == x && _verifica��o[2] == x)
                {
                    VerificarVencedor(x);
                }
                if (_verifica��o[3] == x && _verifica��o[6] == x)
                {
                    VerificarVencedor(x);



                }
                if (_verifica��o[4] == x && _verifica��o[8] == x)
                {
                    VerificarVencedor(x);



                }


            }
            else if (_verifica��o[2] == x)
            {
                if (_verifica��o[5] == x && _verifica��o[8] == x)
                {
                    VerificarVencedor(x);



                }
                else if (_verifica��o[4] == x && _verifica��o[6] == x)
                {
                    VerificarVencedor(x);



                }

            }
            else if (_verifica��o[8] == x)
            {
                if (_verifica��o[7] == x && _verifica��o[6] == x)
                {
                    VerificarVencedor(x);



                }

                if (_verifica��o[1] == x && _verifica��o[7] == x && _verifica��o[4] == x)
                {

                    VerificarVencedor(x);

                }
                if (_verifica��o[3] == x && _verifica��o[4] == x && _verifica��o[5] == x)
                {

                    VerificarVencedor(x);

                }


            }
            bool todosDiferentesDeZero = true;

            foreach (int num in _verifica��o)
            {
                if (num == 0)
                {
                    todosDiferentesDeZero = false;
                    break; 
                }
            }

            if (todosDiferentesDeZero)
            {
                StartCoroutine(Resetar());
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
        if (x == 2)
        {
            Debug.Log("Simbolo vencedor: X");

        }
        else
        {

            Debug.Log("Simbolo vencedor: O");

        }
        StartCoroutine(Resetar());
       

    }
    IEnumerator Resetar()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("jcakons");


    }
    
}