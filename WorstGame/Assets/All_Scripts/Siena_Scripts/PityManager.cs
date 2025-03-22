using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PityManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pityHistoryText; //This text is referring to the "History UI". It'll be influenced by the "pityCounter" integer

    [SerializeField]
    private Star_Image starImage; //This is referring to the "Star_Image" script

    [HideInInspector]
    public bool isItAFiveStar; //This bool will be passed into "starImage" methods

    [HideInInspector]
    public int [] trackingCharacterNumbers = new int [10]; 
    //This integer array will be passed to the "Reveal_Ten_Characters" script and will track the characters when a ten pull is done by the player

    private int reservedCharacterNumber = 0; //This integer will be used to pass into the "trackingCharacterNumbers" 
    private int pityCounter = 0;

    private float randomNumber; //This value is to determine 0-100% if you get the 3.93% of getting a five star
    private float randomCharacter; //This value is to determine out of the 3.93% of getting a five star, which five star you get based on percentages 

    private float garbageGachaRate = 0.9607f; //96.07% of gaining garbage out of 100%
    private float minimumCharacterRate = 0.01f;
    private float maximumCharacterRate = 0.0393f; //3.93% of getting a five star out of 100%
    private float aventurineRate = 0.02751f; //Aventurine rate is 2.751% (70% of 3.93%)
    private float zhongliRate = 0.786f; //Zhongli rate is 0.786%  (20% of 3.93%)

    private bool isItATenPull;

    void Update()
    {
        pityHistoryText.text = pityCounter.ToString();
    }

    public void DetermineGacha(bool possibleTenPull) //This parameter is influenced by the "GachaButton" script
    {
        isItATenPull = possibleTenPull;
        
        if(isItATenPull == false) //This is for when the player does a SINGLE pull
        {
            randomNumber = Random.value; //Random.value function generates a random number between 0,1, INCLUDING 0 AND 1

            if(randomNumber <= garbageGachaRate) //If the "randomNumber" is SMALLER OR EQUAL to the "garbageGachaRate"
            {
                pityCounter++;
                isItAFiveStar = false;
                starImage.WhichCharacterRarity(isItAFiveStar, 0); 
                //Calling the "WhichCharacterRarity" method in "starImage" while passing "isItAFiveStar" and 0 as parameters into the method
            }

            if(randomNumber > garbageGachaRate || pityCounter >=  90) //If the "randomNumber" is BIGGER THAN the "garbageGachaRate" OR "pityCounter" is BIGGER OR EQUAL TO 99
            {
                pityCounter = 0;
                DetermineFiveStar();
            }
        }

        if(isItATenPull == true) //This is for when the player does a TEN pull
        {
            for(int i = 0; i < 10; i++)
            {
                randomNumber = Random.value; //Random.value function generates a random number between 0,1, INCLUDING 0 AND 1
 
                if(randomNumber <= garbageGachaRate) //If the "randomNumber" is SMALLER OR EQUAL to the "garbageGachaRate"
                {
                    pityCounter++;
                    trackingCharacterNumbers[i] = 0;

                    if(isItAFiveStar == true) //Checking if at any-time during the for-loop if "DetermineFiveStar" method was called, which sets "isItAFiveStar" to true
                        continue;

                    else
                        isItAFiveStar = false;
                }

                if(randomNumber > garbageGachaRate || pityCounter >=  90) //If the "randomNumber" is BIGGER THAN the "garbageGachaRate" OR "pityCounter" is BIGGER OR EQUAL TO 99
                {
                    pityCounter = 0;
                    DetermineFiveStar();
                    trackingCharacterNumbers[i] = reservedCharacterNumber;
                }
            }

            starImage.CheckingCharacterRarities(isItAFiveStar);
            //Calling the "CheckingCharacterRarities" method in "starImage" while passing "isItAFiveStar" as a parameter into the method

            isItAFiveStar = false;
        }
    }

    private void DetermineFiveStar()
    {
        pityCounter = 0;
        randomCharacter = Random.Range(minimumCharacterRate, maximumCharacterRate);
        isItAFiveStar = true;

        if(isItATenPull == false)
        {
            if(randomCharacter < aventurineRate)//if "randomCharacter" is SMALLER than "aventurineRate"
                starImage.WhichCharacterRarity(isItAFiveStar, 1);
                //Calling the "WhichCharacterRarity" method in "starImage" while passing "isItAFiveStar" and 1 as parameters into the method

            if(randomCharacter > aventurineRate) //if "randomCharacter" is BIGGER than "aventurineRate"
            {
                if(randomCharacter <= (aventurineRate + zhongliRate)) //if "randomCharacter" is SMALLER THAN OR EQUAL TO (aventurineRate + zhongliRate)
                    starImage.WhichCharacterRarity(isItAFiveStar, 2);
                    //Calling the "WhichCharacterRarity" method in "starImage" while passing "isItAFiveStar" and 2 as parameters into the method
                
                else
                    starImage.WhichCharacterRarity(isItAFiveStar, 3);
                    //Calling the "WhichCharacterRarity" method in "starImage" while passing "isItAFiveStar" and 3 as parameters into the method
            }
        }

        if(isItATenPull == true)
        {
            if(randomCharacter < aventurineRate)//if "randomCharacter" is SMALLER than "aventurineRate"
                reservedCharacterNumber = 1;
        
            if(randomCharacter > aventurineRate) //if "randomCharacter" is BIGGER than "aventurineRate"
            {
                if(randomCharacter <= (aventurineRate + zhongliRate)) //if "randomCharacter" is SMALLER THAN OR EQUAL TO (aventurineRate + zhongliRate)
                    reservedCharacterNumber = 2;
                    
                else
                    starImage.WhichCharacterRarity(isItAFiveStar, 3);
                    //Calling the "WhichCharacterRarity" method in "starImage" while passing "isItAFiveStar" and 3 as parameters into the method
            }
        }
    }
}
