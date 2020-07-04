using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopViewPlayButton : SingleTon<TopViewPlayButton>
{
    public GameObject target;
    Button button { get => target.GetComponentInChildren<Button>(); }

    void Start()
    {
        button.onClick.AddListener(OnClick);
        target.gameObject.SetActive(false);
    }

    void OnClick()
    {
        CameraMover.isPauseByButton = false;
    }

    public void Open(bool o)
    {
        target.gameObject.SetActive(o);
    }
}
