using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene management

public class GameRestart : MonoBehaviour
{
    [SerializeField]
    private AudioSource metalPipeSound;
    [SerializeField]
    private GameObject deathUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
            metalPipeSound.Play();
            deathUI.SetActive(true);

            GatchaBalls.totalGatcha = 0; // Jazmines A3 change
            PlayerMovement.totalOrbsCollected = 0; // Jazmines A3 change

            StartCoroutine(RestartScene()); // Jazmines A3 change
        }
    }

    private IEnumerator RestartScene() // Jazmines A3 change
    {
        yield return new WaitForSeconds(2); // Jazmines A3 change
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Jazmines A3 change
    }
}
