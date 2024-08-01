using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class AddManager : MonoBehaviour
{
    [SerializeField] private GameObject[] adPrefabs; // Array of ad prefabs
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points
    [SerializeField] private Canvas uiCanvas; // Reference to the UI canvas
    [SerializeField] private AudioSource airhornSound;

    private void OnEnable()
    {
        // Register the event when the player jumps
        PlayerMovement.OnJump += SpawnAd;
    }

    private void OnDisable()
    {
        // Unregister the event when the player jumps
        PlayerMovement.OnJump -= SpawnAd;
    }

    private void SpawnAd()
    {
        // Get a random ad prefab and spawn point
        int randomAdIndex = UnityEngine.Random.Range(0, adPrefabs.Length);
        int randomSpawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

        // Instantiate the ad at the spawn point under the UI canvas
        GameObject adInstance = Instantiate(adPrefabs[randomAdIndex], spawnPoints[randomSpawnIndex].position, Quaternion.identity, uiCanvas.transform);
        airhornSound.Play();
    }
}
