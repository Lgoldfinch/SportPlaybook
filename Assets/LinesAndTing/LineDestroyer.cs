using UnityEngine;

public class LineDestroyer : MonoBehaviour
{
    public void DeleteLine(Transform playerTransform)
    {
        if (playerTransform.childCount > 2) DeleteLineHelper(true); // If the user tries to draw a new line when one line exists, delete the existing line. 

        if (playerTransform.childCount == 2) DeleteLineHelper(false); // if the player is moved and a line exists, delete the existing line.
    }

    private void DeleteLineHelper(bool needANewLine)
    {
        LineCreator lineCreator = gameObject.GetComponent<LineCreator>();
        Destroy(GetComponent<Transform>().GetChild(1).gameObject);
        
        if (needANewLine) lineCreator.lineExists = true; // this means a new line can be made.
        
        else lineCreator.lineExists = false; 
    }
}