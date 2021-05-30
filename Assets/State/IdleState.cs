using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] State _attackState;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (_opponentTag == "") return;
        if (collision.gameObject == null) return;
        if (collision.gameObject.CompareTag(_opponentTag))
        {
            Debug.Log(collision.gameObject.tag);
            _actionCtrl.SetCurrent(_attackState);
        }
    }
}
