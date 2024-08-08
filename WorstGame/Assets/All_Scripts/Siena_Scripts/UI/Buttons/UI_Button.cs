using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//Jazmine A3 Programming

public class UI_Button : MonoBehaviour
{
    [Header ("UI Information")]
    [SerializeField]
    private GameObject currentUI;
    [SerializeField]
    private GameObject uiToSwitchTo;

    public UnityEvent GachaEvent;

    [SerializeField]
    private AudioSource popClickSound;

    public void OnPlayerButtonClick()
    {
        popClickSound.Play();
        currentUI.SetActive(false);
        uiToSwitchTo.SetActive(true);
        GachaEvent.Invoke();
    }
}
