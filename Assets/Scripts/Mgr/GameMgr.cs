using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private static GameMgr _instance;

    public static GameMgr Instance
    {
        get => _instance;
    }

    public UIMgr UiMgr
    {
        get;
        private set;
    }

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        
    }
}
