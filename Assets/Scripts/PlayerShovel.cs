using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShovel : MonoBehaviour
{
    //Variables
    [SerializeField] LayerMask SnowLayer; //Reference to the snow layer so that the player can shovel it

    //RayCast2D variables
    RaycastHit2D hit;


    // Update is called once per frame
    void Update()
    {
        //Raycast Code
         hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.right, 1f, SnowLayer);
    
        //Check to see if the raycast has hit something and print a message to the console if something is detected
        if(hit)
        {
            Debug.Log("Snow Detected");
            Debug.Log(hit.collider.name);

            //Shovel Mechanic with left mouse click

            if(Input.GetMouseButtonDown(0)) //0 presents
            {
                ShovelSnow(hit.collider.gameObject);  //Checks the gameObject that the raycast hit to see if it has the snow tag
                Debug.Log("Snow destroyed!");
            }
        }
        else
        {
            Debug.Log("Nothing Detect");
        }        
    }

    //Method to handle shovel mechanic
    private void ShovelSnow(GameObject snowObject)
    {
        if(snowObject.CompareTag("Snow")) //Checks if the GameObject has the "Snow tag 
        {
            Debug.Log("Snow is being Sholved!");
            Destroy(snowObject); // it will then destory the snow object!
        }
        else
        {
            Debug.Log("This is not snow, what are you doing!");
        }
    }
}
