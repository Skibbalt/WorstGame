using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 5f; //Distance the platform will move on the x-axis
    [SerializeField]
    private float moveSpeed = 2f; //Speed of the platform's movement

    private Vector3 originalPosition;
    private float newPositionX;

    void Awake()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        newPositionX = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - moveDistance / 2;
        transform.position = new Vector3(originalPosition.x + newPositionX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision) //This is to move the player along with the game object this script is attached to
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision) //This is to STOP the player moving along with the game object this script is attached to
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
