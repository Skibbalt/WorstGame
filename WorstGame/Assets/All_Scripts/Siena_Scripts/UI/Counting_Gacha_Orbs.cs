using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counting_Gacha_Orbs : MonoBehaviour
{
    [SerializeField]
    private TMP_Text gachaOrbInventoryText;

    void Update()
    {
        gachaOrbInventoryText.text = "X " + GatchaBalls.totalGatcha.ToString(); //Calling the "GatchaBalls" script and accessing the variable named "totalGatcha"
    }
}
