using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CountingOrbs : MonoBehaviour
{
    private int allOrbsInScene;

    void Awake()
    {
        allOrbsInScene = GameObject.FindGameObjectsWithTag("Orb").Length;
        Debug.Log("This is the amount of orbs in the scene: " + allOrbsInScene);
    }
}
