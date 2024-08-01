using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reveal_Ten_Characters : MonoBehaviour
{
    [Header("Parameters for Reveal Ten Characters UI")]
    [SerializeField]
    private Image [] characterImageSlots = new Image [10]; //This will be influenced by the "characters" array
    [SerializeField]
    private Sprite [] characters = new Sprite [3];
    [SerializeField]
    private PityManager pityManager; //This is referring to the "PityManager" script
    [SerializeField]
    private GameObject revealTenCharactersUI;
    [SerializeField]
    private AudioSource omgAventurineSound;

    private bool playAventurineSound = false;

    public void DisplayAllCharacters() 
    //Here, we're grabbing the "trackingCharacterNumbers" array from the "PityManager" script to determine 
    //what index of the "characters" sprite array will fill the "characterImageSlots"'s image sprites
    {
        revealTenCharactersUI.SetActive(true);

        for(int i = 0; i < characterImageSlots.Length; i++)
        {
            if(pityManager.trackingCharacterNumbers[i] == 0)
               characterImageSlots[i].sprite =  characters[0];

            if(pityManager.trackingCharacterNumbers[i] == 1)
            {
                playAventurineSound = true;
                characterImageSlots[i].sprite =  characters[1];
            }

            if(pityManager.trackingCharacterNumbers[i] == 2)
               characterImageSlots[i].sprite =  characters[2];
        }

        if(playAventurineSound == true)
            omgAventurineSound.Play();
    }
}
