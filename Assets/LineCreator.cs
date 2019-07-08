using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject lineGo = Instantiate(linePrefab);
            activeLine = lineGo.GetComponent<Line>();
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        activeLine.UpdateLine(mousePos);
    }
}