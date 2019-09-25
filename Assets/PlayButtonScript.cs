using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayButtonScript : MonoBehaviour
{
    public bool movementEnabled;
    public Player player;
    private PlayerMovement playerMovement;
    private Line runningLine;
    private LineCreator lineCreatorScript; 
       
    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        lineCreatorScript = player.GetComponent<LineCreator>();
    }

    public void LightTheBeacons()
    {
        movementEnabled = true;
    }
}


// We need access to the list of vector 2's so we can provide movement.
// Apparently we can only access the line's list of points at the point of instantiation. Which is in LineCreator.
// We need to be able to provide multiple lists of vector 2s for different players.
// lets see if we can access the list of vectors of a line at all. 
