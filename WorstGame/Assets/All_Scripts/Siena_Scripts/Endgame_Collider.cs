using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame_Collider : MonoBehaviour
{
   [SerializeField]
    private GameObject endGameUI;
    [SerializeField]
    private PlayerMovement player;

    private Rigidbody2D playerRigidBody;

    void Awake()
    {
        playerRigidBody = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            endGameUI.SetActive(true);
        }
    }
}
