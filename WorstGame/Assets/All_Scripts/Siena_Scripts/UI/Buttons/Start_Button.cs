using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Button : MonoBehaviour
{
    [Header ("UI Information")]
    [SerializeField]
    private GameObject currentUI;
    [SerializeField]
    private GameObject uiToSwitchTo;

    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private AudioSource popClickSound;

    private Rigidbody2D playerRigidBody;

    void Awake()
    {
        playerRigidBody = player.GetComponent<Rigidbody2D>();
    }

    public void OnPlayerButtonClick()
    {
        popClickSound.Play();
        currentUI.SetActive(false);
        uiToSwitchTo.SetActive(true);
        AllowPlayerMovement();
    }

    private void AllowPlayerMovement()
    {
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
