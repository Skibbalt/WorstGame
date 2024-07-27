using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PityManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pityHistoryText;

    [SerializeField]
    private Star_Image starImage;

    [HideInInspector]
    public bool isItAFiveStar;

    private float randomNumber; //This value is to determine 0-100% if you get the 3.93% of getting a five star
    private float randomCharacter; //This value is to determine out of the 3.93% of getting a five star, which five star you get based on percentages 

    private float garbageGachaRate = 0.9607f; //96.07% of gaining garbage out of 100%
    private float minimumCharacterRate = 0.01f;
    private float maximumCharacterRate = 0.0393f; //3.93% of getting a five star out of 100%
    private float aventurineRate = 0.02751f; //Aventurine rate is 2.751% (70% of 3.93%)
    private float zhongliRate = 0.786f; //Zhongli rate is 0.786%  (20% of 3.93%)

    private int pityCounter = 0;

    void Update()
    {
        pityHistoryText.text = pityCounter.ToString();
    }

    public void DetermineGacha(bool isItATenPull)
    {
        if(isItATenPull == false) //This is for when the player does a SINGLE pull
        {
            randomNumber = Random.value; //Random.value function generates a random number between 0,1, INCLUDING 0 AND 1

            if(randomNumber <= garbageGachaRate)
            {
                pityCounter++;
                isItAFiveStar = false;
                starImage.WhichCharacterRarity(isItAFiveStar);
                Debug.Log("Your pity is: " + pityCounter); //Just for testing
            }

            if(randomNumber > garbageGachaRate || pityCounter >=  99)
            {
                pityCounter = 0;
                isItAFiveStar = true;
                starImage.WhichCharacterRarity(isItAFiveStar);
                DetermineFiveStar();
            }
        }

        if(isItATenPull == true) //This is for when the player does a TEN pull. WORK ON THIS!
        {
            for(int i = 0; i < 10; i++)
            {
                randomNumber = Random.value; //Random.value function generates a random number between 0,1, INCLUDING 0 AND 1

                if(randomNumber <= garbageGachaRate)
                {
                    pityCounter++;
                    isItAFiveStar = false;

                    Debug.Log("Your pity is: " + pityCounter); //Just for testing
                }

                if(randomNumber > garbageGachaRate || pityCounter >=  99)
                {
                    pityCounter = 0;
                    isItAFiveStar = true;

                    DetermineFiveStar();
                }
            }
        }
    }

    private void DetermineFiveStar()
    {
        pityCounter = 0;
        randomCharacter = Random.Range(minimumCharacterRate, maximumCharacterRate);

        if(randomCharacter < aventurineRate) //if "randomCharacter" is SMALLER than "aventurineRate"
            Debug.Log("You win Aventurine!"); //Just for testing

        if(randomCharacter > aventurineRate) //if "randomCharacter" is BIGGER than "aventurineRate"
        {
            if(randomCharacter <= (aventurineRate + zhongliRate)) //if "randomCharacter" is SMALLER THAN OR EQUAL TO (aventurineRate + zhongliRate)
                Debug.Log("You win Zhongli!"); //Just for testing
            else
                Debug.Log("You win a random person!"); //Just for testing
        }
    }
}