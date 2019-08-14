using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGraveyard : MonoBehaviour
{
    int clicked = 0;
    float clickTime = 0;
    float clickDelay = 0.5f;

    private void DoubleClickLineCreation()
    {
        clicked++;
        if (clicked == 1) clickTime = Time.time;

        if (clicked > 1 && Time.time - clickTime < clickDelay)
        {
            clicked = 0;
            clickTime = 0;
            //MakeLine();
        }
        else if (clicked > 2 || Time.time - clickTime > 1) clicked = 0;
    }
}
