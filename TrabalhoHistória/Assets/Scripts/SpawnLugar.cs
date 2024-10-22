using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLugar : MonoBehaviour
{
    public GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        int aleatorio = Random.Range(0, spawns.Length);
        transform.position = spawns[aleatorio].transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
