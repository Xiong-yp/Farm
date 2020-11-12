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
    public ConfigMgr ConfigMgr
    {
        get;
        private set;
    }
    public HourseMgr HourseMgr
    {
        get;
        private set;
    }

    private void Awake()
    {
        _instance = this;
        Init();
        HourseMgr = gameObject.AddComponent<HourseMgr>();
        HourseMgr.Inst();
        ConfigMgr = gameObject.AddComponent<ConfigMgr>();
        ConfigMgr.Inst();
    }

    void Init()
    {
        
    }
}
