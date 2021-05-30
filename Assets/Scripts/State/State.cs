using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public enum Event
    {
        Update,     //更新
        Enter,      //ステートに来た時
        Leave,      //ステートを離脱した時
    }

    public delegate int EventDelegate();
    protected ActionCtrl _actionCtrl = null;
    protected string _opponentTag = "";
    private Dictionary<int, EventDelegate> _delegates = new Dictionary<int, EventDelegate>();

    protected virtual void Setup()
    {

    }

    protected void SetDelegate(Event evt, EventDelegate dlg)
    {
        _delegates.Add((int)evt, dlg);
    }

    public int EventCall(Event evt)
    {
        if (_delegates.ContainsKey((int)evt))
        {
            return _delegates[(int)evt]();
        }
        return -1;
    }

    public void SetCtrl(ActionCtrl ctrl)
    {
        _actionCtrl = ctrl;
    }

    void Awake()
    {
        if (this.gameObject.name.Contains("Player"))
        {
            _opponentTag = "Enemy";
        }

        if (this.gameObject.name.Contains("Enemy"))
        {
            _opponentTag = "Player";
        }
        Setup();
        this.enabled = false;
    }
}