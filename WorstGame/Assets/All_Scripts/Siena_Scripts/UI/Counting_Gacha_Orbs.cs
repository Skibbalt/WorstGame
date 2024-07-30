using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counting_Gacha_Orbs : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private TMP_Text gachaOrbInventoryText;

    void Update()
    {
        //if (gachaOrbInventoryText.text != GatchaBalls.totalCoins.ToString())
            //gachaOrbInventoryText.text = ("X " + GatchaBalls.totalCoins.ToString());
        gachaOrbInventoryText.text = ("X " + player.totalOrbsCollected);
    }
}
