using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour 
{

    //Enums to hold the present types - There are 3 types, Sweet, Toy, and Plush 
    public enum PresentType {Sweet, Toy, Plush}

    private int score; //Varible to hold the score number

    //Array to hold the Present types
    public PresentType[] presentsAvailable;

    //Make the manager an instance
    public static GameManager Instance;

    //Refernece to the score UI text to update 
    [SerializeField] TMP_Text scoreText;


    void Awake() 
    {
        if(Instance ==   null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


   //Method to handle giving the child the correct present 

   public void CorrectPresent()
   {
        Debug.Log("you gave the child the right present!");
        //Insert "Ho" "Ho" "Ho" Clip here - Audio Clip (Play one shot)
        //Increase the score

        IncreaseScore(10); //Increase the score by 10
   }

   public void inCorrectPresent()
   {
        Debug.Log("Uh-oh Santa, you gave the child the wrong present!");
        //Insert "Upset child noise here"   - Audio Clip (Play one shot)

        //Decrease the score 
        DecreaseScore(5); //Decrease the score by 5 
   }

   //Create new method for adding and decreasing score based on if the player has given the correct present or not

   void IncreaseScore(int amount) //Method to add to the score
   {
        score += amount;
        scoreText.text = score.ToString();
   }

   void DecreaseScore(int amount) //Method to remove from the score 
   {
        score -= amount;
        scoreText.text = score.ToString();
        
   }
}
