using UnityEngine;

public class LineCreator : MonoBehaviour { 

    public GameObject linePrefab;
    public Line activeLine;
    public GameObject playButton;
    public bool lineExists;
    private Player player;

    private void Start()
    {
         player = gameObject.GetComponent<Player>();
    }

    private void Update()
    {
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
        player.runningLine = activeLine;
        lineExists = true;
    }
}
