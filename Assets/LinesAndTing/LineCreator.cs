using UnityEngine;

public class LineCreator : MonoBehaviour { 

    public GameObject linePrefab;
    public Line activeLine;
    //public Player player;

    private void Update()
    {
        //if (player.isPlayerRightclicked)
        //{
        //    Debug.Log(player.isPlayerRightClicked);
        //    //   Debug.Log(player.isPlayerRightclicked);

        //    MakeLine();
        //}

        //if (Input.GetMouseButtonUp(1)) activeLine = null;
        //    //player.isPlayerRightclicked = false;
        
        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }

    public void MakeLine()
    {
        GameObject lineGo = Instantiate(linePrefab);
        activeLine = lineGo.GetComponent<Line>();
		activeLine.transform.SetParent(transform);   
    }
}