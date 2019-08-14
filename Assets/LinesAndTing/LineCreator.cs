using UnityEngine;

public class LineCreator : MonoBehaviour { 

    public GameObject linePrefab;
    Line activeLine;
    int clicked;
    float clickTime;
    float clickDelay = 0.5f;
    private ChangeTextOfButton changeTextScript;
    public bool isPlayerDraggable = true;

  void Update()
    {
        if (Input.GetMouseButtonDown(0)) DoubleClickLineCreation();
        

        if (Input.GetMouseButtonUp(0)) activeLine = null;
        

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }
  
    private void DoubleClickLineCreation()
    {
        isPlayerDraggable = true;
        clicked++;
        if (clicked == 1) clickTime = Time.time; // initial click 

        if (clicked > 1 && Time.time - clickTime < clickDelay) // double click 
        {
            clicked = 0;
            clickTime = 0;
            MakeLine();
            isPlayerDraggable = false; 

        }
        else if (clicked > 2 || Time.time - clickTime > 1) clicked = 0; // too long
    }
  
    private void MakeLine()
    { 
        GameObject lineGo = Instantiate(linePrefab);
        activeLine = lineGo.GetComponent<Line>();
		activeLine.transform.SetParent(transform);   
    }
}