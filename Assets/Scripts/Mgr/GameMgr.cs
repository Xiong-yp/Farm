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

<<<<<<< HEAD
    public UIMgr UiMgr
=======
    public UIMgr UIMgr
    {
        get;
        private set;
    }
    public ConfigMgr ConfigMgr
    {
        get;
        private set;
    } 
    public TimeMgr TimeMgr
    {
        get;
        private set;
    }
    public HourseMgr HourseMgr
>>>>>>> parent of da34b860 (1)
    {
        get;
        private set;
    }

    private void Awake()
    {
        Init();
<<<<<<< HEAD
<<<<<<< HEAD
=======
        TimeMgr = gameObject.AddComponent<TimeMgr>();
=======
        /*TimeMgr = gameObject.AddComponent<TimeMgr>();
>>>>>>> parent of da34b860 (1)
        TimeMgr.Inst();
        HourseMgr = gameObject.AddComponent<HourseMgr>();
        HourseMgr.Inst();
        ConfigMgr = gameObject.AddComponent<ConfigMgr>();
        ConfigMgr.Inst();*/
        BuildMgr = gameObject.AddComponent<BuildMgr>();
        BuildMgr.Init();
        UIMgr = gameObject.AddComponent<UIMgr>();
<<<<<<< HEAD
        //UIMgr.Init();
>>>>>>> parent of acc7fed0 (1)
=======
        UIMgr.Init();
>>>>>>> parent of da34b860 (1)
    }

    void Init()
    {
        
    }
}
