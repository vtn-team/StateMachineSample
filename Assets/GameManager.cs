using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player _player;

    static GameManager _instance = null;
    static public Player Player => _instance._player;

    //適当なのでちゃんとしたシングルトンではない
    void Start()
    {
        _instance = this;
    }
}
