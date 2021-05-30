using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    State _idleState;
    string OpponentTag = "";
    [SerializeField] Animator _animator = null;

    protected override void Setup()
    {
        _idleState = GetComponent<IdleState>();
        SetDelegate(Event.Enter, EnterCallback);
        SetDelegate(Event.Leave, ExitCallback);
    }

    int EnterCallback()
    {
        Debug.Log("EnterCallback");
        _animator.SetBool("Attack", true);
        if(_opponentTag == "Player")
        {
            this.transform.LookAt(GameManager.Player.transform.position);
        }
        return 0;
    }

    int ExitCallback()
    {
        Debug.Log("ExitCallback");
        _animator.SetBool("Attack", false);
        return 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (_opponentTag == "") return;
        if (collision.gameObject == null) return;
        if (collision.gameObject.CompareTag(_opponentTag))
        {
            _actionCtrl.SetCurrent(_idleState);
        }
    }
}
