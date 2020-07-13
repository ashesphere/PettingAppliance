using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExtractor : MonoBehaviour
{
    public GameObject catRoot;
    public AreaTrigger plusArea;
    public Transform plusAreaRoot;
    public ClickTrigger plusButton;
    public AreaTrigger minusArea;
    public ClickTrigger minusButton;
    public Transform minusAreaRoot;
    public float catSizeMin = 0.3f;
    public float catSizeMax = 1f;
    public float catSizeDelta = 0.3f;
    public AreaTrigger ventilatorArea;
    public Transform ventilatorRoot;
    public CameraMover cameraMoverToMiniGame;
    public GameObject miniGameRoot;

    float currentSize;
    AreaTrigger currentSizeController;

    IEnumerator Start()
    {
        currentSize = 1f;
        plusArea.onTargetDrop.AddListener(()=>{
            catRoot.transform.position = plusAreaRoot.position;
            currentSizeController = plusArea;
        });
        plusButton.action.AddListener(()=>{
            AddCatSize();
        });
        minusArea.onTargetDrop.AddListener(()=>{
            catRoot.transform.position = minusAreaRoot.position;
            currentSizeController = minusArea;
        });
        minusButton.action.AddListener(()=>{
            AddCatSize();
        });
        ventilatorArea.onTargetDrop.AddListener(()=>{
            if (currentSize <= catSizeMin)
            {
                catRoot.transform.position = ventilatorRoot.position;
                cameraMoverToMiniGame.gameObject.SetActive(true);
                miniGameRoot.SetActive(true);
            }
        });
        yield break;
    }

    void AddCatSize()
    {
        if (currentSizeController == plusArea)
            currentSize += catSizeDelta;
        if (currentSizeController == minusArea)
            currentSize -= catSizeDelta;
        currentSize = Mathf.Clamp(currentSize, catSizeMin, catSizeMax);
        catRoot.transform.localScale = currentSize * Vector3.one;

        ventilatorArea.gameObject.SetActive(currentSize <= catSizeMin);
    }
}
