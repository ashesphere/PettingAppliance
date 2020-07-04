using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Cursor")] //让Assets界面的右键创建菜单多一个选项
public class MouseCursorSetting : ScriptableObject
{
    public static MouseCursorSetting current { get => Resources.Load<MouseCursorSetting>("MouseCursorSetting"); }

    public Vector2 offset = Vector2.zero;
    public List<Texture2D> cursors;
    public Texture2D defaultCursor;
    
    [Header("Old")]
    public Texture2D click1;
    public Texture2D click2;
    public Texture2D drag1;
    public Texture2D drag2;
    public Texture2D scroll;
}
