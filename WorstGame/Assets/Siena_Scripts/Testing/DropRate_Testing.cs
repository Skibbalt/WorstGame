using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRate_Testing : MonoBehaviour
{
    private float randomNumber;
    private float randomCharacter;

    private float garbageGachaRate = 0.9607f; //96.07% of gaining garbage out of 100%
    private float minimumCharacterRate = 0.01f;
    private float maximumCharacterRate = 0.0393f; //3.93% of getting a five star out of 100%
    private float aventurineRate = 0.02751f; //Aventurine rate is 2.751% (70% of 3.93%)
    private float zhongliRate = 0.786f; //Zhongli rate is 0.786%  (20% of 3.93%)

    private int counter = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            randomNumber = Random.value; //Random.value function generates a random number between 0,1, INCLUDING 0 AND 1
            //Debug.Log("Counter is now at: " + counter);

            if(randomNumber <= garbageGachaRate)
                counter++;

            if(counter == 3 || randomNumber > garbageGachaRate) //if counter equals 3 OR if the "randomNumber" is BIGGER than "garbageGachaRate"
            {
                counter = 0; 
                randomCharacter = Random.Range(minimumCharacterRate, maximumCharacterRate);
                Debug.Log("The randomized gacha rate is: " + randomCharacter);

                if(randomCharacter < aventurineRate) //if "randomCharacter" is SMALLER than "aventurineRate"
                    Debug.Log("You win Aventurine!");

                if(randomCharacter > aventurineRate) //if "randomCharacter" is BIGGER than "aventurineRate"
                {
                    if(randomCharacter <= (aventurineRate + zhongliRate)) //if "randomCharacter" is SMALLER THAN OR EQUAL TO (aventurineRate + zhongliRate)
                        Debug.Log("You win Zhongli!");
                    else
                        Debug.Log("You win a random person!");
                }
            }
        }
    }
}
