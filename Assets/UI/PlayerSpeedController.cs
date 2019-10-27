using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerSpeedController : MonoBehaviour, IPointerUpHandler
{
    private Slider slider;
    public PlayerMovement playerMovement;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void SetInitialMovementSpeed(float movementSpeed, PlayerMovement playerMovementScript)
    {
        slider.value = movementSpeed;
        playerMovement = playerMovementScript;
    }

    public void OnPointerUp(PointerEventData eventData) // when the user releases the slider, set the players movement speed. 
    {
        if (playerMovement == null) return;
        SetPlayerMovementSpeed(); 
    }

    private void SetPlayerMovementSpeed()
    {
        playerMovement.moveSpeed = (int)slider.value;
    }
}
