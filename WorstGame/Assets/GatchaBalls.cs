using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GatchaBalls : MonoBehaviour
{
    //Keep track of total picked  up
    public static int totalCoins = 0;

    void Awake()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
       
        if (c2d.CompareTag("Player"))
        {
            //Add coin to counter
            totalCoins++;
           
            Destroy(gameObject);
        }
    }
}
