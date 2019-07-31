using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDestroyer : MonoBehaviour
{

    public Transform playerTransform;
    private void Update()
    {
        DeleteLine();
    }


    private void DeleteLine()
    {
        if (playerTransform.childCount > 2)
        {
            Destroy(GetComponent<Transform>().GetChild(1).gameObject);
        }
    }
}