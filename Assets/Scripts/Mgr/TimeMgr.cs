using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMgr : MonoBehaviour
{
    private float _time;
    private float _day;
    private float _hour;
    private float _min;
    private float _seconds;
    private float _timeRate=3000f;
    public float _Time { get => _time; private set => _time = value; }

    public float _Hour { get => _hour; private set => _hour = value; }
    public float _Min { get => _min; private set => _min = value; }
    public float _Seconds { get => _seconds; private set => _seconds = value; }

    public void Inst()
    {
        _time = 0;
        _day = 0;
        _hour = 0;
        _min = 0;
        _seconds = 0;
        _Time = 0;

        //InvokeRepeating("TimeAdd", 0, 300);
    }

     void Update()
    {
        TimeAdd();
    }

    void TimeAdd()
    {
        _seconds += Time.deltaTime * _timeRate;
        if (_seconds>=60)
        {
            _min++;
            _seconds =0;
        
        }
        if (_min>=60)
        {
            _hour++;
            _time++;
            _min = 0;
        }
        if (_hour>=24)
        {
            _day++;
            _hour = 0;
        }

        //_time += Time.deltaTime*_timeRate;

        //if (_Time < 23)
        //    _Time++;
        //else
        //    _Time = 0;
        Eventsys.RaiseeShowTime(_Time);
        Debug.Log("Time:" + _Time+"；天数："+_day+"；小时："+_Hour+"；分钟："+_Min+"；秒："+_Seconds);
    }
}
