using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ActionCtrl _actionCtrl = null;

    void Awake()
    {
        _actionCtrl = new ActionCtrl();
        _actionCtrl.SetCurrent(GetComponent<IdleState>());
    }
}
