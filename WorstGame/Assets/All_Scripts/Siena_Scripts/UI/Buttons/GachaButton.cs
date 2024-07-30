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

    [SerializeField]
    private PlayerMovement player;

    public void OnGachaButtonClick()
    {
        if(isTenPull == false)
        {
            if(player.totalOrbsCollected - 1 > -1) 
            {
                gachaRevealUI.SetActive(true);
                pityManager.DetermineGacha(isTenPull); 
                //Calling the "DetermineGacha" method in the "PityManager" script while passing the "isTenPull" boolean parameter into the method
                player.totalOrbsCollected = player.totalOrbsCollected - 1;
            }
        }

        if(isTenPull == true)
        {
            if(player.totalOrbsCollected - 10 > -1) 
            {
                gachaRevealUI.SetActive(true);
                pityManager.DetermineGacha(isTenPull); 
                //Calling the "DetermineGacha" method in the "PityManager" script while passing the "isTenPull" boolean parameter into the method
                player.totalOrbsCollected = player.totalOrbsCollected - 10;
            }
        }
    }
}

//gachaRevealUI.SetActive(true);
//pityManager.DetermineGacha(isTenPull); //Calling the "DetermineGacha" method in the "PityManager" script while passing the "isTenPull" boolean parameter into the method
