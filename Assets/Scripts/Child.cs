using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    //Reference to the Game Manager
    public GameManager.PresentType wantedPresent; //What present does the child want

    //Use a bool to check if a child has already received a present
    bool hasChildRecivedPresent = false;

    //Method to check the present give by Santa (the player)

    public void RecivePresent(GameManager.PresentType givenPresent)
    {
        if(hasChildRecivedPresent) //If the bool is true then print a message saying this child has already recieved a present
        {
            Debug.Log("You've already given this child a present, Santa!");
            return;
        }

        if(givenPresent == wantedPresent)
        {
            Debug.Log("Chid:Thanks Santa!");
            //Call method from game manager
            GameManager.Instance.CorrectPresent();
        }
        else
        {
            Debug.Log("Santa, that's the wrong present!");
            //Call incorrect method from game manager
            GameManager.Instance.inCorrectPresent();
        }
    }
}
