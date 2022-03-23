using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameNPC : MonoBehaviour
{

   // private GameObject[] getCount;
    int count;
    void Start()
    {

        // getCount = GameObject.FindGameObjectsWithTag("Takodachi");
        
    }
    // Update is called once per frame
    void Update()
    {
       // count = GameObject.transform.childCount;
        Debug.Log(count);

        if (count == 0)
            Debug.Log("Game has ended");
    }
}
