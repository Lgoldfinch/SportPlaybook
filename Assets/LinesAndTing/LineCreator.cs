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
        if (Input.GetMouseButtonDown(1))
        {
            MakeLine();
        }

        if (Input.GetMouseButtonUp(1)) activeLine = null;


        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }
  
    private void MakeLine()
    { 
        GameObject lineGo = Instantiate(linePrefab);
        activeLine = lineGo.GetComponent<Line>();
		activeLine.transform.SetParent(transform);   
    }
}