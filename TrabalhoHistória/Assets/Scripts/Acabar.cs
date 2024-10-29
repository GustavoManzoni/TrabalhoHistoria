using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Acabar : MonoBehaviour
{
    public GameObject bana;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(aaa());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator aaa()
    {
        yield return new WaitForSeconds(cooldown);
        bana.SetActive(true);

    }
    public void cred()
    {
        SceneManager.LoadScene("Creditos");


    }
}
