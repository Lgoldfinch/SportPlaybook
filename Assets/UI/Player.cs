﻿using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private LineCreator lineCreatorScript;
    public  Line runningLine;
    public  GameObject playButton;
    public  PlayerMovement playerMovement;
    public  int playerNumber;
    public  static bool isLookingForPassRecipient;

    public bool isLineBeingDrawn;

    public GameObject drawAndEditBtn;
    DrawAndEdit drawAndEditScript;

    BoxCollider2D collider2d;

    private void Start()
    {
        lineCreatorScript = GetComponent<LineCreator>();
        playerMovement = GetComponent<PlayerMovement>();
        drawAndEditScript = drawAndEditBtn.GetComponent<DrawAndEdit>();

        collider2d = GetComponent<BoxCollider2D>();
}

 void Update()
    {
        if (Input.GetMouseButtonUp(0) && isLineBeingDrawn)
        {
            lineCreatorScript.activeLine = null;
            Debug.Log(isLineBeingDrawn);
            isLineBeingDrawn = false;
        }
    }

    public void GondorCallsForAid()
    {
        if (lineCreatorScript.lineExists)
        {
            StartCoroutine(playerMovement.MusterTheRohirrim(runningLine.GetLine()));
        }
    }

    public void OnMouseDown()
    {
        if (drawAndEditScript.isDrawAndEditMode)
        {   
            isLineBeingDrawn = true;
            lineCreatorScript.MakeLine();
        }
    }

    public void SetPlayerKitNumber()
    {
        Text text = gameObject.GetComponentInChildren<Text>();
        text.text = playerNumber.ToString();
    }

    public bool ModifyPlayerCollider(bool isDrawAndEditMode) //TODO reduce duplication between this and the collider deactivator in Line. 
    {
        var actualLine = GetComponentInChildren<Line>();

        if (actualLine == null) // cover possbility that the line hasn't been drawn yet.
        {
            if (isDrawAndEditMode)
            {
                return collider2d.enabled = true; // TODO this can be simplified.
            }
            return collider2d.enabled = true;
        }

        else { 
            if (isDrawAndEditMode)
            {
                runningLine.ModifyLineCollider(isDrawAndEditMode);
                return collider2d.enabled = false;
            }

            runningLine.ModifyLineCollider(isDrawAndEditMode);
            return collider2d.enabled = true;
        }
    }
}

    