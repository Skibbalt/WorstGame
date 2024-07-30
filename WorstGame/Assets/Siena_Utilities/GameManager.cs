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
    }
}
