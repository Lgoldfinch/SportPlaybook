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
        if (playerTransform.childCount > 2) Destroy(GetComponent<Transform>().GetChild(1).gameObject);

        if (playerMoved && playerTransform.childCount == 2) Destroy(GetComponent<Transform>().GetChild(1).gameObject);
    }
}