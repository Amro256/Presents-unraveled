using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpanwer : MonoBehaviour
{
    //Variables
    [SerializeField] GameObject childPrefab;
    [SerializeField] Transform SpawnPoint; //Where the child will spawn
    [SerializeField] Transform targetPoint; //Where the child will walk up to
    [SerializeField] Transform exitPoint; //Where the child will exit to off screen
    [SerializeField] private float spawnDelay = 20f; //Time between Spawns

    
    void Start()
    {
       //Call cotroutine here 
       StartCoroutine(SpawnChild());
    }

   //Use an Ienumator to Spawn children
   private IEnumerator SpawnChild()
   {
        while(true)
        {
            //Instantiate the child
            GameObject child = Instantiate(childPrefab, SpawnPoint.position,Quaternion.identity);
            Child childScript = child.GetComponent<Child>(); //Get the child script
            Debug.Log("Child Spawned");

            //Assign the target / exit points
            childScript.targetPosition = targetPoint;
            childScript.exitPosition = exitPoint;
         
            yield return new WaitForSeconds(spawnDelay);
        }
   }
}
