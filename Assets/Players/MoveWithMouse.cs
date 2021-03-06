﻿using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    Vector2 minPos;
    Vector2 maxPos;
    [SerializeField]
    bool isBeingHeld;

    public GameObject drawAndEditBtn; 
    DrawAndEdit drawAndEditScr;
    LineDestroyer lineDestroyer;

    void Awake()
    {
        var spriteInChild = GetComponentInChildren<SpriteRenderer>();
        var sprite = GetComponent<SpriteRenderer>();
        lineDestroyer = GetComponent<LineDestroyer>();

        if (spriteInChild == null)
        {
            SetExtremaOfSprite(sprite);
        }

        if (sprite == null)
        {
            SetExtremaOfSprite(spriteInChild);
        }

        drawAndEditScr = drawAndEditBtn.GetComponent<DrawAndEdit>();
    }

    void Update()
    {
        if (isBeingHeld)
        {
            drawAndEditScr = drawAndEditBtn.GetComponent<DrawAndEdit>();

            if (!drawAndEditScr.isDrawAndEditMode)
            {
                Vector2 mousePos = Input.mousePosition;
                Vector2 mousePosToWorldPoint = Camera.main.ScreenToWorldPoint(mousePos);
                Vector2 targetPos = new Vector2(mousePosToWorldPoint.x, mousePosToWorldPoint.y);

                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
                transform.position = targetPos;
            }
        }
 
}

    private void OnMouseDown()
    {
        if (!drawAndEditScr.isDrawAndEditMode)
        {
            lineDestroyer.DeleteLine(transform);
            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
            if (isBeingHeld)
        {
            isBeingHeld = false;
        }
    }

    private void SetExtremaOfSprite(SpriteRenderer sprite)
    {
        Vector2 sizeOfSprite = sprite.bounds.extents;

        minPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(0, 0)) + sizeOfSprite;
        maxPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) - sizeOfSprite;
        return;
    }
}
