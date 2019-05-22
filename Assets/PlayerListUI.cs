
using UnityEngine;

public class PlayerListUI : MonoBehaviour // we want to have a player instead of an item
{
    PlayerListUI playerList;

    #region Singleton
    public static PlayerListUI instance;

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PlayerListUI found");
        }
        instance = this;
    }
    #endregion

    void Start()
    {
        playerList = instance;
   //     playerList.onButtonClickedCallback
          }

    // Update is called once per frame
    void UpdateUI()
    {
        
    }
}
