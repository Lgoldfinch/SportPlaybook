﻿using System.Collections;
using UnityEngine;

public class LineCreator : MonoBehaviour { 

    public GameObject linePrefab;
    Line activeLine;
    int clicked = 0;
    float clickTime = 0;
    float clickDelay = 0.5f;

    //void OnMouseDown() ///// So things to consider - We need to cater to 2 different types of event. B) DoubleClick C) drag. Both drag and DC follow the click.
        // Both the player drag and the player click need to be initated when the object is clicked.
        //  So the order of priority needs to be : Person clicks on player and drags. If the player follows this with another click in a certain timeframe then a line will be drawn instead (ending the drag maybe???). So maybe I have to go
        // from 
    //{
    //    DoubleClickLineCreation();

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Debug.Log("unclick hit");
    //        activeLine = null;
    //    }

    //    if (activeLine != null)
    //    {
    //        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        activeLine.UpdateLine(mousePos);
    //    }
    //}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MakeLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }

    //private void DoubleClickLineCreation()
    //{
    //    clicked++;
    //    if (clicked == 1) clickTime = Time.time;

    //    if (clicked > 1 && Time.time - clickTime < clickDelay)
    //    {
    //        clicked = 0;
    //        clickTime = 0;
    //        MakeLine();

    //    }
    //    else if (clicked > 2 || Time.time - clickTime > 1) clicked = 0;
    //}

    private void MakeLine()
    {
      
        GameObject lineGo = Instantiate(linePrefab);
        activeLine = lineGo.GetComponent<Line>();
		activeLine.transform.SetParent(transform);   
    }
}
