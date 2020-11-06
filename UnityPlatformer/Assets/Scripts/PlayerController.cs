using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //The Rigidbody2D is used to handle this object's physics.
    private Rigidbody2D rigidbody2D;

    //We'll use this to keep track of when this object is touching the ground and when it isn't 
    //- so we'll know when it should be allowed to jump.
    private bool isOnGround = false;

    //A reference to the GameManager
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //When this player has been created it will try to find a Rigidbody2D component and store it in a variable.
        rigidbody2D = this.GetComponent<Rigidbody2D>();

        //Find the GameManager by searhing for its GameObject in the level, then searching for its script in that.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for keyboard inputs.
        if (Input.GetKey(KeyCode.Space) && isOnGround)//This tests to see if the Spacebar has been pressed AND that this object is touching the ground.
        {
            //Set a new velocity on the Y axis. The velocity on the X axis should remain the same for jumping.
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 10.0f);

            isOnGround = false;//Make sure the player doesn't jump again until it touches the ground.
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//This tests to see if the A key OR Left Arrow key has been pressed.
        {
            //Set a new velocity on the X axis. The velocity on the Y axis should remain the same for moving.
            rigidbody2D.velocity = new Vector2(-5.0f, rigidbody2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//This tests to see if the D key OR Right Arrow key has been pressed.
        {
            //Set a new velocity on the X axis. The velocity on the Y axis should remain the same for moving.
            rigidbody2D.velocity = new Vector2(5.0f, rigidbody2D.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TileMap")
        {
            isOnGround = true;
        }
        else if (collision.gameObject.tag == "Lava")//If the player has hit Lava then they need to be returned to the last waypoint
        {
            //Get the current waypoint from the GameManager
            GameObject waypoint = gameManager.getCurrentWaypoint();

            //Now get the Transform object from the waypoint's GameObject, this holds the location data.
            Transform waypointLocation = waypoint.transform;

            //Now set this object's (the player's) poisition to the waypoint's, so the player will be teleported there.
            this.transform.position = waypointLocation.position;

            //A better way to write the code above is:
            //this.transform.position = gameManager.getCurrentWaypoint().transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TileMap")
        {
            isOnGround = false;
        }
    }
}
