using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageExtractor : MonoBehaviour
{
    public GameObject catRoot;
    //public AreaTrigger plusArea;
    //public Transform plusAreaRoot;
    public AreaTrigger catSizeArea;
    public Transform catSizeAreaRoot;
    public ClickTrigger plusButton;
    public ClickTrigger minusButton;
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
    int canChangeCatSize;

    IEnumerator Start()
    {
        currentSize = 1f;
        /*
        plusArea.onTargetDrop.AddListener(()=>{
            catRoot.transform.position = plusAreaRoot.position;
            currentSizeController = plusArea;
        });
        */
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

    public void SetCatSizeEnable(int s)
    {
        canChangeCatSize = s;
    }

    public void AddCatSize(float d)
    {
        if (Mathf.Sign(d) != Mathf.Sign(canChangeCatSize))
            return;
        //if (currentSizeController == plusArea)
            currentSize += catSizeDelta * d;
        //if (currentSizeController == catSizeArea)
        //    currentSize -= catSizeDelta;
        currentSize = Mathf.Clamp(currentSize, catSizeMin, catSizeMax);
        catRoot.transform.localScale = currentSize * Vector3.one;

        ventilatorArea.gameObject.SetActive(currentSize <= catSizeMin);
        if (currentSize <= catSizeMin)
            whenCatSizeReachMin.Invoke();
        else
            whenCatSizeLeaveMin.Invoke();
    }
}
