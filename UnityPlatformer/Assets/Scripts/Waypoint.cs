using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //The index of this waypoint (each waypoint will have a different index).
    public int waypointIndex;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Set this as the new waypoint in the GameManager, so the player will know they can respawn here if they die.
            gameManager.setNewWaypoint(waypointIndex);

            //Get the SpriteRenderer for this waypoint and set its sprite to the green flag sprite stored in the GameManager.
            this.GetComponent<SpriteRenderer>().sprite = gameManager.waypointGreenSprite;

            //Another way of writing this is:
            //SpriteRenderer mySpriteRenderer = this.GetComponent<SpriteRenderer>();
            //mySpriteRenderer.sprite = gameManager.waypointGreenSprite;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
