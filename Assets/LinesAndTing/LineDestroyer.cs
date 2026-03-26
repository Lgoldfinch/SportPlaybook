using UnityEngine;

public class LineDestroyer : MonoBehaviour
{
    public void DeleteLine(Transform playerTransform)
    {
        if (playerTransform == null)
            return;

        var lineCreator = playerTransform.GetComponent<LineCreator>();
        Line lineToDestroy =
            (lineCreator != null && lineCreator.activeLine != null) ? lineCreator.activeLine : playerTransform.GetComponentInChildren<Line>();

        if (lineToDestroy != null)
            Destroy(lineToDestroy.gameObject);

        // Keep state consistent for subsequent play/draw.
        if (lineCreator != null)
        {
            lineCreator.activeLine = null;
            lineCreator.lineExists = false;
        }

        var player = playerTransform.GetComponent<Player>();
        if (player != null)
            player.runningLine = null;
    }
}