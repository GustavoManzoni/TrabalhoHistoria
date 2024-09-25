using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] minions, spawns;
    public GameObject minion;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            for(int i = 0; i < minions.Length; i++)
            {
                if (minions[i] == null)
                {
                    StartCoroutine(spawnar(i));


                }

            }


            timer = 0;
        }
    }
    IEnumerator spawnar(int i)
    {
        yield return new WaitForSeconds(10);

        GameObject instancia = Instantiate(minion, spawns[i].transform.position, spawns[i].transform.rotation);
        minions[i] = instancia; 


    }
}
