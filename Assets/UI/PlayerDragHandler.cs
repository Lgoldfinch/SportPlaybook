﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDragHandler : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld;
    public GameObject playerSpeedSlider;
    private PlayerSpeedController playerSpeedController;
    private PlayerMovement playerMovementScript;

    private void Awake()
    {
        //playerMovementScript = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (isBeingHeld == true)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.WorldToScreenPoint(mousePos);

            gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ViewportToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;

            isBeingHeld = true;

            //AttachSpeedSliderToClickedPlayer();
        }
    }

    //private void AttachSpeedSliderToClickedPlayer()
    //{
    //    playerSpeedController = playerSpeedSlider.GetComponent<PlayerSpeedController>();
    //    playerSpeedController.SetInitialMovementSpeed(playerMovementScript.moveSpeed, playerMovementScript);
    //}

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    transform.localPosition = Vector2.zero;
    //}

    // transform.localPosition = Vector2.zero; This will be useful for BinBehaviour. 
}
