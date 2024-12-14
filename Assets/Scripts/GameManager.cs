using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

    //Enums to hold the present types - There are 3 types, Sweet, Toy, and Plush 
    public enum PresentType {Sweet, Toy, Plush}

    //Array to hold the Present types
    public PresentType[] presentsAvailable;

    //Make the manager an instance
    public static GameManager Instance;

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
        //Insert "Ho" "Ho" "Ho" Clip here
   }

   public void inCorrectPresent()
   {
        Debug.Log("Uh-oh Santa, you gave the child the wrong present!");
        //Insert "Upset child noise here"    
   }
}
