using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourseMgr : MonoBehaviour
{

    GameObject _hourseParent;
    List<GameObject> _temphourse=new List<GameObject>();

    public List<GameObject> Temphourse
    {
        get => _temphourse;
        set => _temphourse = value;
    }

    public void Inst()
    {
        _hourseParent = GameObject.Find("Farm/home");
        for (int i = 0; i < _hourseParent.transform.childCount; i++)
        {
            Temphourse.Add(_hourseParent.transform.GetChild(i).gameObject);
            _hourseParent.transform.GetChild(i).gameObject.AddComponent<Hourse>();
        }
    }
}
