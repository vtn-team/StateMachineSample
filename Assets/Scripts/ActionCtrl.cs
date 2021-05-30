using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCtrl
{
    State _currentState = null;
    
    public void SetCurrent(State s)
    {
        if (s == null) return;
        if(_currentState != null)
        {
            _currentState.EventCall(State.Event.Leave);
        }

        _currentState = s;
        _currentState.SetCtrl(this);
        _currentState.EventCall(State.Event.Enter);
    }
}
