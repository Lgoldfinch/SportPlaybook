using UnityEngine;

public class LineCreator : MonoBehaviour { 

    public GameObject linePrefab;
    Line activeLine;
    public Player player;

   private void Update()
    {
        if (Input.GetMouseButtonDown(1) && player.isPlayerRightclicked)
        {
         //   Debug.Log(player.isPlayerRightclicked);

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