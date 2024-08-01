using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaButton : MonoBehaviour
{
    public bool isTenPull;

    [SerializeField]
    private PityManager pityManager; //This is referring to the "PityManager" script

    [SerializeField]
    private GameObject gachaRevealUI; //This parameter will be the "Star Reveal UI" Game Object

    public void OnGachaButtonClick()
    {
        if(isTenPull == false)
        {
            if(GatchaBalls.totalGatcha - 1 > -1) 
            {
                gachaRevealUI.SetActive(true);
                pityManager.DetermineGacha(isTenPull); 
                //Calling the "DetermineGacha" method in the "PityManager" script while passing the "isTenPull" boolean parameter into the method
                GatchaBalls.totalGatcha = GatchaBalls.totalGatcha - 1;
            }
        }

        if(isTenPull == true)
        {
            if(GatchaBalls.totalGatcha - 10 > -1) 
            {
                gachaRevealUI.SetActive(true);
                pityManager.DetermineGacha(isTenPull); 
                //Calling the "DetermineGacha" method in the "PityManager" script while passing the "isTenPull" boolean parameter into the method
                GatchaBalls.totalGatcha = GatchaBalls.totalGatcha - 10;
            }
        }
    }
}

//gachaRevealUI.SetActive(true);
//pityManager.DetermineGacha(isTenPull); //Calling the "DetermineGacha" method in the "PityManager" script while passing the "isTenPull" boolean parameter into the method
