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
<<<<<<< HEAD
=======
        TimeMgr = gameObject.AddComponent<TimeMgr>();
        TimeMgr.Inst();
        HourseMgr = gameObject.AddComponent<HourseMgr>();
        HourseMgr.Inst();
        ConfigMgr = gameObject.AddComponent<ConfigMgr>();
        ConfigMgr.Inst();
        BuildMgr = gameObject.AddComponent<BuildMgr>();
        //BuildMgr.Init();
        UIMgr = gameObject.AddComponent<UIMgr>();
        //UIMgr.Init();
>>>>>>> parent of acc7fed0 (1)
    }

    void Init()
    {
        
    }
}
