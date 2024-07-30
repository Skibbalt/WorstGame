using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button : MonoBehaviour
{
    [Header ("UI Information")]
    [SerializeField]
    private GameObject currentUI;
    [SerializeField]
    private GameObject uiToSwitchTo;

    [SerializeField]
    private AudioSource popClickSound;

    public void OnPlayerButtonClick()
    {
        popClickSound.Play();
        currentUI.SetActive(false);
        uiToSwitchTo.SetActive(true);
    }
}
