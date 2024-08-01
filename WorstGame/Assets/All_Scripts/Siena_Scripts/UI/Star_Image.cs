using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star_Image : MonoBehaviour
{
    [Header("Parameters for Star Image UI")]
    [SerializeField]
    private Image imagePlaceholder; //This will be influenced by the "starSprites" array
    [SerializeField]
    private Sprite [] starSprites = new Sprite [2];
    [SerializeField]
    private GameObject starRevealUI;
    [SerializeField]
    private AudioSource metalPipeSound;
    
    [SerializeField]
    private Reveal_Single_Character revealSingleCharacterUI; //This is referring to the "Reveal_Single_Character" script

    [SerializeField]
    private Reveal_Ten_Characters revealTenCharactersUI; //This is referring to the "Reveal_Ten_Characters" script
 
    public void WhichCharacterRarity(bool highRarity, int characterNumber) //This is for when the player does a SINGLE pull
    {
        if(highRarity == false)
        {
            imagePlaceholder.sprite = starSprites[0]; //Adjusting "imagePlaceholder"'s sprite to a "starSprites" index at 0
            metalPipeSound.Play();
            StartCoroutine("SwitchToCharacterRevealUI", characterNumber); 
        }

        if(highRarity == true)
        {
            imagePlaceholder.sprite = starSprites[1]; //Adjusting "imagePlaceholder"'s sprite to a "starSprites" index at 1
            metalPipeSound.Play();
            StartCoroutine("SwitchToCharacterRevealUI", characterNumber);
        }

        if(highRarity == true && characterNumber == 3)
        {
            imagePlaceholder.sprite = starSprites[1]; //Adjusting "imagePlaceholder"'s sprite to a "starSprites" index at 1
            metalPipeSound.Play();
            StartCoroutine("QuitOnThePlayer");
        }
    }

    public void CheckingCharacterRarities(bool highRarity) //This is for when the player does a TEN pull
    {
        if(highRarity == false)
        {
            imagePlaceholder.sprite = starSprites[0]; //Adjusting "imagePlaceholder"'s sprite to a "starSprites" index at 0
            metalPipeSound.Play();
            StartCoroutine("SwitchToTenCharacterRevealUI");
        }

        if(highRarity == true)
        {
            imagePlaceholder.sprite = starSprites[1]; //Adjusting "imagePlaceholder"'s sprite to a "starSprites" index at 1
            metalPipeSound.Play();
            StartCoroutine("SwitchToTenCharacterRevealUI");
        }
    }

    IEnumerator QuitOnThePlayer()
    {
        float time = 0.5f;
        yield return new WaitForSeconds(time);
        StopAllCoroutines();
        Application.Quit(); //Close the app. This is to be used for when you build a Unity project.
    }

    IEnumerator SwitchToCharacterRevealUI(int charNumber)
    {
        float time = 0.5f;
        yield return new WaitForSeconds(time);
        starRevealUI.SetActive(false);
        revealSingleCharacterUI.DisplayCharacter(charNumber);
        //Calling the "DisplayCharacter" method in "revealSingleCharacterUI" while passing "charNumber" as a parameter in the method

        yield return null;
    }

    IEnumerator SwitchToTenCharacterRevealUI()
    {
        float time = 0.5f;
        yield return new WaitForSeconds(time);
        starRevealUI.SetActive(false);
        revealTenCharactersUI.DisplayAllCharacters();
        //Calling the "DisplayAllCharacters" method in "revealTenCharactersUI" 

        yield return null;
    }
}

//UnityEditor.EditorApplication.isPlaying = false; //Exit out the player editor in Unity
//Application.Quit(); //Close the app. This is to be used for when you build a Unity project.