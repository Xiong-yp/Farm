using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMgr : MonoBehaviour
{
    float _Nowtime;
    float _time;
    public float _Time { get => _time; set => _time = value; }

    public void Inst()
    {
        InvokeRepeating("TimeAdd", 3, 3);
    }

    private void FixedUpdate()
    {
        _Nowtime += Time.deltaTime;
 
    }

    void TimeAdd()
    {
        if (_Time < 23)
            _Time++;
        else
            _Time = 0;
        Eventsys.RaiseeShowTime(_Time);
    }
}
