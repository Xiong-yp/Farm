using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class Eventsys
{
    public delegate void ShowTime(float _nowTime);
    static public event ShowTime GrowthTime;
    static public void RaiseeShowTime(float _nowTime)
    {
        GrowthTime(_nowTime);
    }
}
