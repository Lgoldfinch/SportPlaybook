using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    Vector2 minPos;
    Vector2 maxPos;
    [SerializeField]
    bool isBeingHeld;

    public GameObject drawAndEditBtn; 
    DrawAndEdit drawAndEditScr;
    LineDestroyer lineDestroyer;
    Collider2D collider2d;

    void Awake()
    {
        var spriteInChild = GetComponentInChildren<SpriteRenderer>();
        var sprite = GetComponent<SpriteRenderer>();
        lineDestroyer = GetComponent<LineDestroyer>();
        collider2d = GetComponent<Collider2D>();

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
        drawAndEditScr = drawAndEditBtn.GetComponent<DrawAndEdit>();

        if (isBeingHeld)
        {
            if (!drawAndEditScr.isDrawAndEditMode)
            {
                if (PointerInput.IsPointerOverUI())
                    return;

                Vector2 worldPos = Camera.main.ScreenToWorldPoint(PointerInput.PointerPosition);
                Vector2 targetPos = new Vector2(worldPos.x, worldPos.y);

                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
                transform.position = targetPos;
            }
        }

        if (!isBeingHeld && !drawAndEditScr.isDrawAndEditMode && PointerInput.PointerDownThisFrame())
        {
            if (PointerInput.IsPointerOverUI())
                return;

            if (collider2d != null && collider2d.enabled)
            {
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(PointerInput.PointerPosition);
                if (collider2d.OverlapPoint(worldPos))
                {
                    lineDestroyer.DeleteLine(transform);
                    isBeingHeld = true;
                }
            }
            else
            {
                // Fallback: if we don't have a collider, we can't do hit-testing.
            }
        }

        if (isBeingHeld && PointerInput.PointerUpThisFrame())
            isBeingHeld = false;
 
}


    private void SetExtremaOfSprite(SpriteRenderer sprite)
    {
        Vector2 sizeOfSprite = sprite.bounds.extents;

        minPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(0, 0)) + sizeOfSprite;
        maxPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) - sizeOfSprite;
        return;
    }
}
