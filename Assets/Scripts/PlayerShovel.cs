using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShovel : MonoBehaviour
{
    //Variables
    [SerializeField] LayerMask SnowLayer; //Reference to the snow layer so that the player can shovel it
    [SerializeField] LayerMask presentsLayer;
    [SerializeField] Transform playerTransform;
    private float fff = 2f;

    [SerializeField] GameManager.PresentType? HeldPresent;
    private GameObject currentPresentObject;
    //RayCast2D variables
    RaycastHit2D hit;


    // Update is called once per frame
    void Update()
    {
        LayerMask combinedLayers = SnowLayer | presentsLayer;

        //Raycast Code
         hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.right, 1f, combinedLayers);

         //RaycastHit2D hitPresents = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.right, 1f, presentsLayer);
    
        //Check to see if the raycast has hit something and print a message to the console if something is detected
        if(hit)
        {
            Debug.Log("Object Detected " + hit.collider.name);
        

            //Shovel Mechanic with left mouse click

            if(Input.GetMouseButtonDown(0)) //0 presents
            {
                ShovelSnow(hit.collider.gameObject);  //Checks the gameObject that the raycast hit to see if it has the snow tag
                Debug.Log("Snow destroyed!");
            }

            if(Input.GetMouseButtonDown(1)) //1 represents right button click
            {

                if(HeldPresent.HasValue)
                {
                    Debug.Log("You're already holding a present");
                    return;
                }

                    if(hit.collider.CompareTag("Sweet"))
                    {
                        presentPickup(hit.collider.gameObject, GameManager.PresentType.Sweet);
                        Debug.Log("You collected a Candy Cane");
                    }
                    else if(hit.collider.CompareTag("Toy"))
                    {
                        presentPickup(hit.collider.gameObject, GameManager.PresentType.Toy);
                        Debug.Log("You collected a Toy");
                    }
                    else if(hit.collider.CompareTag("Plush"))
                    {
                        presentPickup(hit.collider.gameObject, GameManager.PresentType.Plush);
                        Debug.Log("You collected a Plush");
                    }     
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

    //Method to handle Item PickUp
    private void presentPickup(GameObject present, GameManager.PresentType presentType)
    {
        HeldPresent = presentType;
        currentPresentObject = present;

        Vector3 presentLocation = playerTransform.position + new Vector3(0, fff, 0);

        present.transform.position = presentLocation;

        present.transform.SetParent(playerTransform);

        GameManager.Instance.startDeliveryTime();
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(HeldPresent.HasValue && other.CompareTag("Child"))
        {
            Child child = other.GetComponent<Child>();

            if(child != null)
            {
                child.RecivePresent(HeldPresent.Value);

                if(currentPresentObject != null)
                {
                    Destroy(currentPresentObject);
                }

                GameManager.Instance.endDeliveryTime(); //Call the end delivery time method

                HeldPresent = null; //Once the player have given the child the present, they wont be holding anything
            }

        }    
    }
}
