using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : SingleTon<CursorController>
{
    [Range(0,1f)]public float scale = 0.03f;
    public float distance = 0.1f;

    MouseCursorSetting cursorData { get => MouseCursorSetting.current; }
    public SpriteRenderer _cursorSprite;
    SpriteRenderer cursorSprite 
    {
        get{
            if (!_cursorSprite)
            {
                _cursorSprite = new GameObject("Cursor Sprite(Created by CursorController)",
                     typeof(SpriteRenderer)).GetComponent<SpriteRenderer>();
                _cursorSprite.transform.SetParent(transform);
            }
            return _cursorSprite;    
        }
    }

    void Start()
    {
        //Cursor.SetCursor(cursorData.defaultCursor, cursorData.offset, CursorMode.Auto);
        cursorSprite.sprite = cursorData.defaultCursor;
    }

    void Update()
    {
        cursorSprite.transform.localScale = Vector3.one * scale;
        var ray = Camera.main.ScreenPointToRay(
            Input.mousePosition
        );
        cursorSprite.transform.position = ray.origin + ray.direction * distance;
        cursorSprite.transform.rotation = Camera.main.transform.rotation;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        cursorSprite.transform.localScale = Vector3.one * scale;
        var ray = Camera.main.ScreenPointToRay(
            Input.mousePosition
        );
        cursorSprite.transform.position = ray.origin + ray.direction * distance;
        cursorSprite.transform.rotation = Camera.main.transform.rotation;
        Cursor.visible = false;
    }

    public void SetCursor(CursorType t)
    {
        int n = (int)t;
        var targetCursor = t == CursorType.None ? cursorData.defaultCursor : cursorData.cursors[n];
        //Cursor.SetCursor(targetCursor, cursorData.offset, CursorMode.Auto);
        cursorSprite.sprite = targetCursor;
    }
}

public enum CursorType
{
    Click1, Click2, Drag1, Drag2, Scroll, None
}