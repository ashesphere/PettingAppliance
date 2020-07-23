using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIGeneral : MonoBehaviour
{
    public Image openSceneImage;
    public List<Sprite> openScenes;
    public UnityEvent onOpenScenesEnd;

    public void ChangeOpenScene()
    {
        var currentScene = openSceneImage.sprite;
        var i = openScenes.IndexOf(currentScene);
        i++;
        if (i == openScenes.Count)
        {
            if (onOpenScenesEnd != null)
                onOpenScenesEnd.Invoke();
        }
        else
            openSceneImage.sprite = openScenes[i];
    }
}
