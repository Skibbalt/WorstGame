using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GatchaBalls : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player; //Siena added this

    //Keep track of total picked  up
    public static int totalCoins = 0;

    void OnTriggerEnter2D(Collider2D c2d)
    {
       
        if (c2d.CompareTag("Player"))
        {
            //Add coin to counter
            totalCoins++;
            player.totalOrbsCollected++; //Siena added this
           
            Destroy(gameObject);
        }
    }
}
