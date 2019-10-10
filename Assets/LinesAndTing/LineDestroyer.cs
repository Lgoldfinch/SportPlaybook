using UnityEngine;

public class LineDestroyer : MonoBehaviour
{
    public Transform playerTransform;
    
    private void Update()
    {
        DeleteLine(false);
    }

    public void DeleteLine(bool playerMoved)
    {
        if (playerTransform.childCount > 2) DeleteLineHelper();

        if (playerMoved && playerTransform.childCount == 2) DeleteLineHelper();
    }

    private void DeleteLineHelper()
    {
        LineCreator lineCreator = gameObject.GetComponent<LineCreator>();
        Destroy(GetComponent<Transform>().GetChild(1).gameObject);
        Debug.Log(lineCreator);
        lineCreator.lineExists = false;
    }
}