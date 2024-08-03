using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("UI Information")]
    [SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private GameObject mainPlatformUI;
    [SerializeField]
    private GameObject gachaBannerUI;
    [SerializeField]
    private GameObject detailsUI;
    [SerializeField]
    private GameObject historyUI;
    [SerializeField]
    private GameObject starRevealUI;
    [SerializeField]
    private GameObject revealSingleCharacterUI;
    [SerializeField]
    private GameObject revealTenCharactersUI;
    [SerializeField]
    private GameObject deathUI;
    [SerializeField]
    private GameObject endGameUI;
    [SerializeField]
    private PlayerMovement player;

    private Rigidbody2D playerRigidBody;

    void Awake() //Only show the Start Menu
    {
        playerRigidBody = player.GetComponent<Rigidbody2D>();

        startMenu.SetActive(true);
        mainPlatformUI.SetActive(false);
        gachaBannerUI.SetActive(false);
        detailsUI.SetActive(false);
        historyUI.SetActive(false);
        starRevealUI.SetActive(false);
        revealSingleCharacterUI.SetActive(false);
        revealTenCharactersUI.SetActive(false);
        deathUI.SetActive(false);
        endGameUI.SetActive(false);

        StopPlayerMovement();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(); //Close the app
    }

    private void StopPlayerMovement() 
    {
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }
}
