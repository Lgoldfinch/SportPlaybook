using UnityEngine;
using System.Linq;

public class DrawAndEdit : MonoBehaviour
{
    public bool isDrawAndEditMode;

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
            return isDrawAndEditMode;
        }

        isDrawAndEditMode = false;
        Debug.Log(isDrawAndEditMode);
        return isDrawAndEditMode;
    }

    public bool ChangePlayerColliders(GameObject listOfPlayersObj)
    {
        var players = listOfPlayersObj.GetComponentsInChildren<Player>();
        var linesBelongingToPlayers = listOfPlayersObj.GetComponentsInChildren<Line>();

        Debug.Log(linesBelongingToPlayers);

       return ColliderAlteringLoop(players, isDrawAndEditMode);
    }

        
        bool ColliderAlteringLoop(Player[] objects, bool colliderEnabled)
        {

        if (objects.Length == 0)
        {
            throw new System.Exception("Should not be empty");
        }

        for (int i = 0; i <= objects.Length - 1; i++)
            {

            return objects[i].collider2d.enabled = colliderEnabled;
            }

        return false; 
        }
}
