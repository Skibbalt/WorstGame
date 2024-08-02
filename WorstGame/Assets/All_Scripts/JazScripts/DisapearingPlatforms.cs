using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatforms : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Invoke("DestroyPlatform", 2f); // Call DestroyPlatform after 2 seconds
    }

    private void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
