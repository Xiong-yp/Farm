using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMgr : MonoBehaviour
{
    public float time;

    public float Time { get => time; set => time = value; }

    // Start is called before the first frame update
    public void Inst()
    {
        InvokeRepeating("TimeAdd", 10, 10);

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
