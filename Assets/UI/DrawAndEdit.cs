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
            Debug.Log(isDrawAndEditMode);
            return isDrawAndEditMode;
        }

        isDrawAndEditMode = false;
        Debug.Log(isDrawAndEditMode);
        return isDrawAndEditMode;
    }
}
