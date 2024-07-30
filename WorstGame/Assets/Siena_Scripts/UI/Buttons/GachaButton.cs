using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaButton : MonoBehaviour //NOTE: THIS SCRIPT WILL HAVE TO BE EDITTED IN ACCORDANCE WITH THE GACHA ORBS IN AN INVENTORY
{
    public bool isTenPull;

    [SerializeField]
    private PityManager pityManager; //This is referring to the "PityManager" script

    [SerializeField]
    private GameObject gachaRevealUI; //This parameter will be the "Star Reveal UI" Game Object

    public void OnGachaButtonClick()
    {
        gachaRevealUI.SetActive(true);
        pityManager.DetermineGacha(isTenPull); //Calling the "DetermineGacha" method in the "PityManager" script while passing the "isTenPull" boolean parameter into the method
    }
}
