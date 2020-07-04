using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConditionTrigger : MonoBehaviour
{
    public int state = 0;
    public List<UnityEvent> actionList;

    public void Act()
    {
        if (state >= 0)
        if (actionList.Count > state)
        {
            if(actionList[state] != null)
                actionList[state].Invoke();
        }
    }

    public void SetState(int s)
    {
        state = s;
    }
}
