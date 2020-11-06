using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //You will need this library to access User Interface objects, like Text output.

public class GameManager : MonoBehaviour
{
    //Instructions panel and all text outputs that will need processing.
    public GameObject instructionPanel;
    public Text instructionText_jump;
    public Text instructionText_left;
    public Text instructionText_right;
    private bool hasJumped = false;
    private bool hasMovedLeft = false;
    private bool hasMovedRight = false;

    //List of all waypoints in the game.
    public GameObject[] allWaypoints;

    //The index to find the most recent waypoint in the array of waypoints.
    private int currentWaypoint = 0;

    //For storing the waypoints' updated sprite for when they need it.
    public Sprite waypointGreenSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Has the player used all of the commands?
        if (hasJumped && hasMovedLeft && hasMovedRight)
        {//They have
            //Set instructionPanel to be invisible by making it unactive - the player should know how to play now.
            instructionPanel.SetActive(false);
        }
        else
        {//They haven't
            //Here we are testing whether the player has used each command yet.
            //When they do we set the relevant bool variable and set its text to yellow.
            if (Input.GetKey(KeyCode.Space))
            {
                hasJumped = true;
                //Set colour of text to yellow to show instruction has been carried out
                instructionText_jump.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                hasMovedLeft = true;
                //Set colour of text to yellow to show instruction has been carried out
                instructionText_left.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                hasMovedRight = true;
                //Set colour of text to yellow to show instruction has been carried out
                instructionText_right.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            }
        }
    }

    public void setNewWaypoint(int waypointIndex)
    {
        //Only set this new index as the current one if it is higher. (So player's don't accidentally reset their progress)
        //Also make sure the value is still less than the maximum number of waypoints (or there might be an array out of bounds error)
        if (waypointIndex > currentWaypoint && waypointIndex < allWaypoints.Length)
            currentWaypoint = waypointIndex;
    }

    public GameObject getCurrentWaypoint()
    {
        return allWaypoints[currentWaypoint];
    }
}
