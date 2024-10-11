using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArvoresRandomicas : MonoBehaviour
{

    public GameObject[] spawns;
    public GameObject avore;
                        
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawns.Length; i++) 
        {
            int vaiTer = Random.Range(0, 3);
            if(vaiTer == 2)
            {
                Instantiate(avore, spawns[i].transform.position, Quaternion.identity);


            }
        
        
        
        
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
