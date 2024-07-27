using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reveal_Character : MonoBehaviour
{
    [SerializeField]
    private GameObject characterRevealUI;

    [SerializeField]
    private Image imagePlaceholder;

    [SerializeField]
    private Sprite [] characters = new Sprite [3];

    public void DisplayCharacter(bool isHighRarity)
    {
        if(isHighRarity == false)
            imagePlaceholder.sprite = characters[0];

        if(isHighRarity == true) //Have to work on this
        {

        }
    }
}
