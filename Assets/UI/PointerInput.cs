using UnityEngine;
using UnityEngine.EventSystems;

// Small helper for touch-first pointer handling without switching to the Input System.
public static class PointerInput
{
    public static Vector2 PointerPosition
    {
        get
        {
            if (Input.touchCount > 0)
                return Input.GetTouch(0).position;

            return Input.mousePosition;
        }
    }

    public static bool PointerDownThisFrame()
    {
        if (Input.touchCount > 0)
            return Input.GetTouch(0).phase == TouchPhase.Began;

        return Input.GetMouseButtonDown(0);
    }

    public static bool PointerUpThisFrame()
    {
        if (Input.touchCount > 0)
        {
            var phase = Input.GetTouch(0).phase;
            return phase == TouchPhase.Ended || phase == TouchPhase.Canceled;
        }

        return Input.GetMouseButtonUp(0);
    }

    public static bool PointerIsHeld()
    {
        if (Input.touchCount > 0)
        {
            var phase = Input.GetTouch(0).phase;
            return phase == TouchPhase.Began || phase == TouchPhase.Moved || phase == TouchPhase.Stationary;
        }

        return Input.GetMouseButton(0);
    }

    public static bool IsPointerOverUI()
    {
        if (EventSystem.current == null)
            return false;

        if (Input.touchCount > 0)
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);

        return EventSystem.current.IsPointerOverGameObject();
    }
}

