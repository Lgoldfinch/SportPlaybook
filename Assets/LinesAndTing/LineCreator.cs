using UnityEngine;

public class LineCreator : MonoBehaviour { 

    public GameObject linePrefab;
    public Line activeLine;
    public GameObject playButton;
    public bool lineExists;
    private Player player;
    private LineDestroyer lineDestroyer;

    private void Start()
    {
         player = gameObject.GetComponent<Player>();
         lineDestroyer = gameObject.GetComponent<LineDestroyer>();
    }

    private void Update()
    {
        if (activeLine != null)
        {
            if (PointerInput.IsPointerOverUI())
                return;

            Vector2 screenPos = PointerInput.PointerPosition;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            activeLine.UpdateLine(worldPos);
        }
    }

    public void MakeLine()
    {
        if (lineExists) lineDestroyer.DeleteLine(transform);

        GameObject lineGo = Instantiate(linePrefab);
        activeLine = lineGo.GetComponent<Line>();
        activeLine.transform.SetParent(transform);
        player.runningLine = activeLine;
        lineExists = true;
    }
}
