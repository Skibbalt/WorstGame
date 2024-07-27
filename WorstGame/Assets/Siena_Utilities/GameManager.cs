using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("UI Information")]
    [SerializeField]
    private GameObject gachaBannerUI;
    [SerializeField]
    private GameObject detailsUI;
    [SerializeField]
    private GameObject historyUI;

    void Awake()
    {
        gachaBannerUI.SetActive(true);
        detailsUI.SetActive(false);
        historyUI.SetActive(false);
    }
}
