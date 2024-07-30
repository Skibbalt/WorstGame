using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GatchaBallsCounter : MonoBehaviour
{
    private TMP_Text counterText;

  
    void Start()
    {
        counterText = GetComponent<TMP_Text>();
    }

   
    void Update()
    {
        // Set the current number of coins to display
        if (counterText.text != GatchaBalls.totalCoins.ToString())
        {
            counterText.text = GatchaBalls.totalCoins.ToString();
        }
    }
}
