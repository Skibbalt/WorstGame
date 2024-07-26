using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaButton : MonoBehaviour
{
    public bool isTenPull;

    [SerializeField]
    private PityManager pityManager;

    public void OnGachaButtonClick()
    {
        pityManager.DetermineGacha(isTenPull);
    }
}
