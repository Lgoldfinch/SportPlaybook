using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBehaviour : MonoBehaviour
{
    public string firstText;
    public string secondText;
    Text text;
    private int counter = 0;
    public GameObject playerPrefab;
    public int numberOfPlayersGroup1;
    public int numberOfPlayersGroup2;

    List<Player> listOfPlayers;

    public void ChangeText()
    {

        if (counter == 0)
        {
            ChangeTextHelper(secondText);
            counter = 1;
        }
        else if (counter > 0)
        {
            ChangeTextHelper(firstText);
            counter = 0;
        }
    }

   
    //public void Start()
    //{ 
    //    for(int i = 1; i < numberOfPlayersGroup1 + 1; i++)
    //    {
    //       Player instanceOfPlayer = playerPrefab.GetComponent<Player>();

    //        string playerNumber = i.ToString();
    //        text = Instantiate(text);
    //        text.text = playerNumber;

    //    //    text.transform.parent = instanceOfPlayer.transform;

    //        listOfPlayers = new List<Player>
    //        {
    //            instanceOfPlayer

    //    };
    //        Instantiate(playerPrefab);
    //    }
    //}
   



        private void ChangeTextHelper(string newText)
        {
            text = GetComponentInChildren<Text>();
            text.text = newText;
        }
    }