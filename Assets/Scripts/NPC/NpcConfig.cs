using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class  NpcConfig
{
    int _id;
    string _name;
    string _modle;
    string _professional;
    string _housename;
    string _tradable;
    int _startwork;
    int _endwork;
    string _speack;
    public NpcConfig(int id, string name, string modle, string professional, string housename,
        string tradable, int startwork, int endwork, string speack)
    {
        _id = id;
        _name = name;
        _modle = modle;
        _professional = professional;
        _housename = housename;
        _tradable = tradable;
        _startwork = startwork;
        _endwork = endwork;
        _speack = speack; 
    }

   
}
