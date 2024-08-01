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

    void Awake() //Only show the Start Menu
    {
        startMenu.SetActive(true);
        mainPlatformUI.SetActive(false);
        gachaBannerUI.SetActive(false);
        detailsUI.SetActive(false);
        historyUI.SetActive(false);
        starRevealUI.SetActive(false);
        revealSingleCharacterUI.SetActive(false);
        revealTenCharactersUI.SetActive(false);
        deathUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(); //Close the app. This is to be used for when you build a Unity project.
    }
}

//UnityEditor.EditorApplication.isPlaying = false; //Exit out the player editor in Unity
//Application.Quit(); //Close the app. This is to be used for when you build a Unity project.
