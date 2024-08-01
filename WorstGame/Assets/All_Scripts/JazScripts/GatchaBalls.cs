using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatchaBalls : MonoBehaviour
{
    [SerializeField] private PlayerMovement player; // Reference to PlayerMovement script

    public static int totalGatcha = 0;

    private void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player"))
        {
            totalGatcha++;
            player.UpdateTotalOrbsCollected(); // Update the player's total orbs collected

            Destroy(gameObject);
        }
    }
}
