using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public UnityEvent whenCatSizeReachMin;
    public UnityEvent whenCatSizeLeaveMin;
    public AreaTrigger ventilatorArea;
    public Transform ventilatorRoot;
    public CameraMover cameraMoverToMiniGame;
    public GameObject miniGameRoot;
    public UnityEvent afterCatSizeBackToOrigin;
    public float timeDelay = 1f;

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
            if(currentSizeController == plusArea)
                AddCatSize();
        });
        minusArea.onTargetDrop.AddListener(()=>{
            catRoot.transform.position = minusAreaRoot.position;
            currentSizeController = minusArea;
        });
        minusButton.action.AddListener(()=>{
            if (currentSizeController == minusArea)
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
        yield return new WaitUntil(()=> miniGameRoot.activeSelf);
        yield return new WaitUntil(()=>!miniGameRoot.activeSelf);
        yield return new WaitUntil(()=>currentSize >= catSizeMax);
        yield return new WaitForSeconds(timeDelay);
        if (afterCatSizeBackToOrigin != null)
            afterCatSizeBackToOrigin.Invoke();
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
        if (currentSize <= catSizeMin)
            whenCatSizeReachMin.Invoke();
        else
            whenCatSizeLeaveMin.Invoke();
    }
}
