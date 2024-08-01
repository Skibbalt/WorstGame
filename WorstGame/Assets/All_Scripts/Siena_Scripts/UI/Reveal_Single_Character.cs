using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Reveal_Single_Character : MonoBehaviour
{
    [Header("Parameters for Reveal Single Character UI")]
    [SerializeField]
    private Image imagePlaceholder; //This will be influenced by the "characters" array
    [SerializeField]
    private TMP_Text characterText;
    [SerializeField]
    private Sprite [] characters = new Sprite [3];
    [SerializeField]
    private GameObject characterRevealUI;
    [SerializeField]
    private AudioSource omgAventurineSound;

    public void DisplayCharacter(int characterNumber)
    {
        characterRevealUI.SetActive(true);

        if(characterNumber == 0)
        {
            imagePlaceholder.sprite = characters[characterNumber]; //Adjusting "imagePlaceholder"'s sprite to a "characters" index at 0
            characterText.text = string.Format("GARBAGE!");
        }

        if(characterNumber == 1)
        {
            imagePlaceholder.sprite = characters[characterNumber]; //Adjusting "imagePlaceholder"'s sprite to a "characters" index at 1
            characterText.text = string.Format("AVENTURINE!");
            omgAventurineSound.Play();
        }

        if(characterNumber == 2)
        {
            imagePlaceholder.sprite = characters[characterNumber]; //Adjusting "imagePlaceholder"'s sprite to a "characters" index at 2
            characterText.text = string.Format("ZHONGLI!");
        }
    }
}
