using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb; // Reference to rigidbody2D
    [SerializeField] float moveSpeed = 5; //Variable to Control the player's movement speed
    float movementX;
    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Will get the player's RB when the game starts 
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxis("Horizontal"); // Movement for left/right, A/D
    }

    void FixedUpdate() 
    {
        //Call the Move Player Method 
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(movementX,0) * moveSpeed * Time.deltaTime;
    }
}
