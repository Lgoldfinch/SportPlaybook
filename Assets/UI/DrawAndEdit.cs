using UnityEngine;
using System.Linq;

public class DrawAndEdit : MonoBehaviour
{
    public bool isDrawAndEditMode;
    public GameObject listOfPlayersObj;
    //private Player[] players;

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

        Transform playersOnField = listOfPlayersObj.transform;

        foreach (Transform player in playersOnField)
        {
            Player playerScript = player.GetComponent<Player>();
            playerScript.ModifyPlayerCollider(isDrawAndEditMode);
        }
        //for (int i = 0; i <= players.Length - 1; i++)
        //{
        //    players[i].ModifyPlayerCollider(isDrawAndEditMode);
        //}
    }
     
        
        //bool ColliderAlteringLoop(Player[] objects, bool drawAndEditMode)
        //{

        //if (objects.Length == 0)
        //{
        //    Debug.LogWarning("There are no players on the pitch.");
        //}



        //for (int i = 0; i <= objects.Length - 1; i++)
        //    {

        //    return objects[i].collider2d.enabled = colliderEnabled;
        //    }



        //return false; 
        //}
}
