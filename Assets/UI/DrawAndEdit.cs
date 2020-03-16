using UnityEngine;

public class DrawAndEdit : MonoBehaviour
{
    public bool isDrawAndEditMode;

    public void DrawAndEditButtonClicked()
    {
        SwitchMode();
    }

    private bool SwitchMode()
    {
        if (!isDrawAndEditMode)
        {
            isDrawAndEditMode = true;
            return isDrawAndEditMode;
        }

        isDrawAndEditMode = false;
        return isDrawAndEditMode;
    }
}
