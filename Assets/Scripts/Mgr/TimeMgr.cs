using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMgr : MonoBehaviour
{
<<<<<<< HEAD
    public float time;
    public float Time { get => time; set => time = value; }

    public void Inst()
    {
        InvokeRepeating("TimeAdd", 3, 3);
=======
    float _Nowtime;
    float _time;
    public float _Time { get => _time; set => _time = value; }

    public void Inst()
    {
        InvokeRepeating("TimeAdd", 300, 300);
    }

    private void FixedUpdate()
    {
        _Nowtime += Time.deltaTime;
       
>>>>>>> master
    }

    void TimeAdd()
    {
<<<<<<< HEAD
        if (Time < 23)
            Time++;
        else
            Time = 0;
        Eventsys.RaiseeShowTime(Time);
=======
        if (_Time < 23)
            _Time++;
        else
            _Time = 0;
        Eventsys.RaiseeShowTime(_Time);
>>>>>>> master
    }
}
