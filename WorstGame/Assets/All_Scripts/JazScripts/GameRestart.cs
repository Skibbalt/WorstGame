using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    [SerializeField]
    private AudioSource metalPipeSound;
    [SerializeField]
    private GameObject deathUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            metalPipeSound.Play();
            deathUI.SetActive(true);
            GatchaBalls.totalGatcha = 0;
        }
    }
}
