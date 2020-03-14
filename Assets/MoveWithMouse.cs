using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    Vector2 minPos;
    Vector2 maxPos;
    Vector2 mousePos;

    void Start()
    {
        var spriteInChild = GetComponentInChildren<SpriteRenderer>();
        var sprite = GetComponent<SpriteRenderer>();

        if (spriteInChild == null)
        {
            SetExtremaOfSprite(sprite);
        }

        if (sprite == null)
        {
            SetExtremaOfSprite(spriteInChild);
        }
    
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = (Input.mousePosition);
            Vector2 targetPos = new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
            transform.position = targetPos;
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
