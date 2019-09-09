using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlayer : MonoBehaviour
{
    public GameObject player;

    public void InstantiateDroppedPlayer()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(player, mousePos, Quaternion.identity);
    }
}
