using UnityEngine;

public class DrawAndEdit : MonoBehaviour
{
    public bool isDrawAndEditMode;
    public GameObject playersOnFieldObj;

    public void DrawAndEditButtonClicked()
    {
        SwitchMode();
    }

    bool SwitchMode() 
    {
        if (!isDrawAndEditMode)
        {
            isDrawAndEditMode = true;

            Debug.Log(isDrawAndEditMode);

            ChangeColliders();

            return isDrawAndEditMode;
        }

        isDrawAndEditMode = false;

        Debug.Log(isDrawAndEditMode);

        ChangeColliders();

        return isDrawAndEditMode;
    }

    public void ChangeColliders()
    {

        Transform playersOnField = playersOnFieldObj.transform;

        foreach (Transform player in playersOnField)
        {
            Player playerScript = player.GetComponent<Player>();

            playerScript.ModifyPlayerCollider(isDrawAndEditMode);
        }  
    }
}
