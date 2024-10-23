using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] minions, spawns;
    public GameObject minion1, minion2, minion3;
    public float timer;
  



    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < minions.Length; i++)
        {
            if (minions[i] == null && i <= 2 && i >= 0)
            {
                StartCoroutine(spawnar(i, minion1, 0));

            }
            if (minions[i] == null && i <= 5 && i >= 3)
            {
                StartCoroutine(spawnar(i, minion2, 0));

            }
            if (minions[i] == null && i <= 8 && i >= 6)
            {
                StartCoroutine(spawnar(i, minion3, 0));

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            for(int i = 0; i < minions.Length; i++)
            {
                if (minions[i] == null && i <= 2 && i >= 0)
                {
                    StartCoroutine(spawnar(i, minion1, 8));

                }
                if (minions[i] == null && i <= 5 && i >= 3)
                {
                    StartCoroutine(spawnar(i, minion2, 8));

                }
                if (minions[i] == null && i <= 8 && i >= 6)
                {
                    StartCoroutine(spawnar(i, minion3, 8));

                }

            }


            timer = 0;
        }
    }
    IEnumerator spawnar(int i, GameObject minionLocal, float cooldown)
    {
       

        GameObject instancia = Instantiate(minionLocal, spawns[i].transform.position, spawns[i].transform.rotation);
        minions[i] = instancia;
        yield return new WaitForSeconds(cooldown);
        minions[i].SetActive(true);



    }
    
}
