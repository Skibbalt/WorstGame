using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GatchaBalls : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player; // Siena added this

    // Keep track of total picked up
    public static int totalGatcha = 0;

    private void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player"))
        {
            // Add coin to counter
            totalGatcha++;
            player.totalOrbsCollected++; // Siena added this

           

            // Destroy the GatchaBall object
            Destroy(gameObject);
        }
    }
}
