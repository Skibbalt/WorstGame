using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star_Image : MonoBehaviour
{
    [SerializeField]
    private Image imagePlaceholder;

    [SerializeField]
    private Reveal_Character revealCharacterUI;

    [SerializeField]
    private Sprite [] starSprites = new Sprite [2];

    public void WhichCharacterRarity(bool highRarity)
    {
        if(highRarity == false)
        {
            imagePlaceholder.sprite = starSprites[0];
            StartCoroutine("SwitchToCharacterUI");

            revealCharacterUI.DisplayCharacter(highRarity);
        }

        if(highRarity == true)
        {
            imagePlaceholder.sprite = starSprites[1];
            StartCoroutine("SwitchToCharacterUI");
            revealCharacterUI.DisplayCharacter(highRarity);
        }
    }

    IEnumerator SwitchToCharacterUI()
    {
        float time = 0.5f;
        yield return new WaitForSeconds(time);

        //revealCharacterUI.DisplayCharacter(highRarity);
        yield return null;
    }
}
