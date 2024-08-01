using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene management

public class GameRestart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.CompareTag("Player"))
        {
            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
