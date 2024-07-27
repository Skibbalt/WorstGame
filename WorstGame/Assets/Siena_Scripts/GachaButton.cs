using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaButton : MonoBehaviour
{
    public bool isTenPull;

    [SerializeField]
    private PityManager pityManager;

    [SerializeField]
    private GameObject gachaRevealUI;

    public void OnGachaButtonClick()
    {
        gachaRevealUI.SetActive(true);
        pityManager.DetermineGacha(isTenPull);
    }
}
