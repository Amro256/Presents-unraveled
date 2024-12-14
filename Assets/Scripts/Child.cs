using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Child : MonoBehaviour
{
    //Variables
    public Transform targetPosition;
    public Transform exitPosition;
    public GameObject desiredPresent; //Visual for what the child wants
    [SerializeField] float moveSpeed = 3f; //Move speed for the child

    //Reference to the Game Manager
    public GameManager.PresentType wantedPresent; //What present does the child want

    //Use a bool to check if a child has already received a present
    bool hasChildRecivedPresent = false;
    bool isChildLeaving = false;

    //Prefabs for the presents 
    [SerializeField] GameObject sweetObject;
    [SerializeField] GameObject toyObject;
    [SerializeField] GameObject plushObject;

    void Start()
    {
        //Call the randomise present method here
        RandomisePresent(); 
        if(desiredPresent != null)
        {
            //Instatation object above the child
            GameObject presentIdicator = Instantiate(desiredPresent, transform.position + Vector3.up * 1.5f, quaternion.identity);
            presentIdicator.transform.SetParent(transform); //Attach the present prefab to the child
        }
    }

    void Update()
    {
        //If the child is not leaving, then move towards target
        if(!isChildLeaving)
        {
            MoveToTarget(targetPosition);
        }
        else
        {
            MoveToTarget(exitPosition);

            //Destory the child after leaving 
            if(Vector2.Distance(transform.position, exitPosition.position) < 0.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    //Method to check the present give by Santa (the player)
    public void RecivePresent(GameManager.PresentType givenPresent)
    {
        if(givenPresent == wantedPresent)
        {
            Debug.Log("Chid: Yay, Thanks Santa! :) ");
            //Call method from game manager
            GameManager.Instance.CorrectPresent();
        }
        else
        {
            Debug.Log("Child: Santa, that's the wrong present! :( ");
            //Call incorrect method from game manager
            GameManager.Instance.inCorrectPresent();
        }

        hasChildRecivedPresent = true;
        isChildLeaving = true;
    }

    //Method to randomise the present (enum) that the child wants
    void RandomisePresent()
    {
        Array enumValue = Enum.GetValues(typeof(GameManager.PresentType)); //Use an array to get all values in the present type Enum
        
        wantedPresent = (GameManager.PresentType) enumValue.GetValue(UnityEngine.Random.Range(0, enumValue.Length)); //Randomise it using random.Range


        //Match the wanted present to the correct visual 

        switch(wantedPresent)
        {
            case GameManager.PresentType.Sweet:
            desiredPresent = sweetObject;
            break;
            case GameManager.PresentType.Toy:
            desiredPresent = toyObject;
            break;
            case GameManager.PresentType.Plush:
            desiredPresent = plushObject;
            break;
        }

        //Now Instantiate the object above the child
        if(desiredPresent != null)
        {
            GameObject presentIndicator = Instantiate(desiredPresent, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            presentIndicator.transform.SetParent(transform); //Attch it to the parent aka the child
        }
        
    }

    //Method to move the child towards the Target / Exit position
    void MoveToTarget(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position,target.position, moveSpeed * Time.deltaTime);
    }
}
