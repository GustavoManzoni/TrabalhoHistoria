using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject preto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        StartCoroutine(Jogar());

    }
     IEnumerator Jogar()
    {
        Fade fade = preto.GetComponent<Fade>();
        preto.SetActive(true);
        yield return new WaitForSeconds(fade.fadeDuration);
        SceneManager.LoadScene("JogoDVerdade");

    }
}
