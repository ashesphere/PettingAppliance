using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Cursor")] //让Assets界面的右键创建菜单多一个选项
public class MouseCursorSetting : ScriptableObject
{
    public static MouseCursorSetting current { get => Resources.Load<MouseCursorSetting>("MouseCursorSetting"); }

    public Vector2 offset = Vector2.zero;
    public List<Sprite> cursors;
    public Sprite defaultCursor;
    
}
