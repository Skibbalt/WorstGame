using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counting_Gacha_Orbs : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private TMP_Text gachaOrbInventoryText;

    void Update()
    {
        // Ensure the text reflects the current number of orbs collected
        string newText = "X " + player.totalOrbsCollected;
        if (gachaOrbInventoryText.text != newText)
        {
            gachaOrbInventoryText.text = newText;
        }
    }
}
