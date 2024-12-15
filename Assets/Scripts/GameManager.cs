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
    
    private float DeliverySpeed; //Variable to track delivery speed 

    [SerializeField] GameObject popUpTextPrefab; //Reference to the Text prefab
    [SerializeField] Transform canvasTrans;
    


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
        endDeliveryTime();
        
   }

   public void inCorrectPresent()
   {
        Debug.Log("Uh-oh Santa, you gave the child the wrong present!");
        //Insert "Upset child noise here"   - Audio Clip (Play one shot)

        //Decrease the score 
        DecreaseScore(5); //Decrease the score by 5 
        DeliverySpeed = 0;
   }

   //public method to start the delivery time
   public void startDeliveryTime() //Call this method when the player picks ups a present
   {
        DeliverySpeed = Time.time;
   }


   //Create a method to calculate the delivery time / end it 

    public void endDeliveryTime()
    {
        if(DeliverySpeed == 0) //Checks if the delivery speed is equal to 0 and 
        return; //if so return nothing (no points added to score)

        float deliveryTime = Time.time - DeliverySpeed; //Check the elapsed time 
        DeliverySpeed = 0; //Reset the timer
        addSpeedScore(deliveryTime);
    }


    //Method to add points based on delivery speed /time

    void addSpeedScore(float deliveryTime)
    {
        int points = 0;
        string message;
        Color color;

        if(deliveryTime <= 5f) //Delivered within 10 seconds - Fast
        {
            points = Random.Range(15, 20);
            message = "Nice work!";
            color = Color.green;
        }
        else if(deliveryTime <= 10f) //Delivered within 15 seconds - Medium
        {
            points = Random.Range(10, 15);
            message = "Not too bad!";
            color = Color.yellow;
            
        }
        else if (deliveryTime <= 15f) //Delivered within 20 seconds - Slow
        {
            points = Random.Range(5, 10);
            message = "Too Slow";
            color = Color.red;
        }
        else
        {
            points = Random.Range(1, 3); //Too slow!
            message = "Are you even trying!";
            color = Color.black; //Maybe change this
        }

        IncreaseScore(points);
        SpawnText(message, color);
    }


   //Create new method for adding and decreasing score based on if the player has given the correct present or not

   void IncreaseScore(int amount) //Method to add to the score
   {
        score += amount;
        scoreText.text = score.ToString(); //You want to get the text component of the TMP and convert the score to string so it can be displayed
   }

   void DecreaseScore(int amount) //Method to remove from the score 
   {
        score -= amount;
        scoreText.text = score.ToString(); //You want to get the text component of the TMP and convert the score to string so it can be displayed
        
   }

    void SpawnText(string message, Color color)
    {
        GameObject PopUp = Instantiate(popUpTextPrefab, canvasTrans);
        TextFadeOut textFade = GetComponent<TextFadeOut>();
        textFade.TextSetUp(message, color);
    }
}
