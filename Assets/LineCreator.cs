using System.Collections;
using UnityEngine;

public class LineCreator : MonoBehaviour { 

    public GameObject linePrefab;
    public GameObject player; 
    Line activeLine;
    int clicked = 0;
    float clickTime = 0;
    float clickDelay = 0.5f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))                                  
        {

            DoubleClickLineCreation();
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

    private void DoubleClickLineCreation()
    {
        clicked++;
        if (clicked == 1) clickTime = Time.time;

        if (clicked > 1 && Time.time - clickTime < clickDelay)
        {
            clicked = 0;
            clickTime = 0;
            MakeLine();

        }
        else if (clicked > 2 || Time.time - clickTime > 1) clicked = 0;
    }

    private void MakeLine()
    {
      
        GameObject lineGo = Instantiate(linePrefab);
        activeLine = lineGo.GetComponent<Line>();
        activeLine.transform.SetParent(player.transform);

        
    }
}
