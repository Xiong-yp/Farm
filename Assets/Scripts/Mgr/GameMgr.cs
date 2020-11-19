<<<<<<< HEAD
﻿using System;
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

    public Camera mainCamera
    {
        get;
        private set;
    }
    
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
    {
        get;
        private set;
    }

    public BuildMgr BuildMgr
    {
        get;
        private set;
    }
    private void Awake()
    {
        _instance = this;
        Init();
    }

    public CameraMgr CameraMgr
    {
        get;
        private set;
    }


    public SunLightMgr SunLightMgr//昼夜光照管理脚本
    {
        get;
       private set;
    }




    void Init()
    {
        mainCamera = Camera.main;
        CameraMgr = gameObject.AddComponent<CameraMgr>();
        CameraMgr.Init();

        TimeMgr = gameObject.AddComponent<TimeMgr>();
        TimeMgr.Inst();
        HourseMgr = gameObject.AddComponent<HourseMgr>();
        HourseMgr.Inst();
        ConfigMgr = gameObject.AddComponent<ConfigMgr>();
        ConfigMgr.Inst();

        //昼夜光照系统
        SunLightMgr = gameObject.AddComponent<SunLightMgr>();
        SunLightMgr.Inst();

        BuildMgr = gameObject.AddComponent<BuildMgr>();
        //BuildMgr.Init();
        UIMgr = gameObject.AddComponent<UIMgr>();
        UIMgr.Init();

       


    }
}
=======
﻿using System;
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

    public Camera mainCamera
    {
        get;
        private set;
    }
    
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
    {
        get;
        private set;
    }

    public BuildMgr BuildMgr
    {
        get;
        private set;
    }
    private void Awake()
    {
        _instance = this;
        Init();
    }

    public CameraMgr CameraMgr
    {
        get;
        private set;
    }

    void Init()
    {
        mainCamera = Camera.main;
        CameraMgr = gameObject.AddComponent<CameraMgr>();
        CameraMgr.Init();

        TimeMgr = gameObject.AddComponent<TimeMgr>();
        TimeMgr.Inst();
        HourseMgr = gameObject.AddComponent<HourseMgr>();
        HourseMgr.Inst();
        ConfigMgr = gameObject.AddComponent<ConfigMgr>();
        ConfigMgr.Inst();

        //BuildMgr = gameObject.AddComponent<BuildMgr>();
        //BuildMgr.Init();
        //UIMgr = gameObject.AddComponent<UIMgr>();
        //UIMgr.Init();
    }
}
>>>>>>> master
