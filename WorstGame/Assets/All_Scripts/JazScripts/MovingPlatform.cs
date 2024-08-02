using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 5f; // Distance the platform will move on the x-axis
    public float moveSpeed = 2f; // Speed of the platform's movement
    private Vector3 originalPosition;
    private bool playerOnPlatform = false;
    //private float moveDirection = 1f; // 1 for right, -1 for left

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        float newPositionX = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - moveDistance / 2;
        transform.position = new Vector3(originalPosition.x + newPositionX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }
}
