using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMgr : MonoBehaviour
{
    public float time;
    public float Time { get => time; set => time = value; }

    public void Inst()
    {
        InvokeRepeating("TimeAdd", 3, 3);
    }

    void TimeAdd()
    {
        if (Time < 23)
            Time++;
        else
            Time = 0;
        Eventsys.RaiseeShowTime(Time);
    }
}
