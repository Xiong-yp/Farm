﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNpcCsvData : MonoBehaviour
{
    string[][] Array;
    public void Inst()
    {
        TextAsset binAsset = Resources.Load("CSV/Npc") as TextAsset;
        string[] temp_lineArray = binAsset.text.Split('\r');
        Array = new string[temp_lineArray.Length][];
        for (int i = 0; i < temp_lineArray.Length; i++)
        {
            Array[i] = temp_lineArray[i].Split(',');
        }
        SaveTableData(Array);
    }
    int _id;
    string _name;
    string _modle;
    string _professional;
    string _housename;
    string _tradable;
    int _startwork;
    int _endwork;
    string _speack;
    int _attack;
    int _attackspeed;
    int _runspeed;
    int _health;
    int _brutal;
    int _price;

    void SaveTableData(string[][] m_array)
    {
        if (m_array.Length == 0)
        {
            return;
        }
        int _nRow = m_array.Length;
        int _nCol = m_array[0].Length;
        for (int i = 1; i < _nRow; i++)
        {
            GameObject _tempnpc;
            for (int j = 0; j < _nCol; j++)
            {
                if (j == 0)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _id = int.Parse(tempid);
                }
                if (j == 1)
                {
                    _name = m_array[i][j];
                }
                if (j == 2)
                {
                    _modle = m_array[i][j];
                }
                if (j == 3)
                {
                    _professional = m_array[i][j];
                }
                if (j == 4)
                {
                    _housename = m_array[i][j];
                }
                if (j == 5)
                {
                    _tradable = m_array[i][j];
                }
                if (j == 6)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _startwork = int.Parse(tempid);
                }
                if (j == 7)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _endwork = int.Parse(tempid);
                }
                if (j == 8)
                {
                    _speack = m_array[i][j];
                }
                if (j == 9)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _attack = int.Parse(tempid);
                }
                if (j == 10)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _attackspeed = int.Parse(tempid);
                }
                if (j == 11)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _runspeed = int.Parse(tempid);
                }
                if (j == 12)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _health = int.Parse(tempid);
                }
                if (j == 13)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _brutal = int.Parse(tempid);
                }
                if (j == 14)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _price = int.Parse(tempid);
                }
            }
            _tempnpc = Instantiate(Resources.Load(string.Format("{0}{1}", "Npc/", _modle)) as GameObject);
            _tempnpc.SetActive(false);
            _tempnpc.AddComponent<NPC>().Inst(_id, _name, _modle, _professional, _housename, _tradable, _startwork, _endwork, _speack, _attack, _attackspeed, _runspeed, _health, _brutal, _price);

            for (int x = 0; x < GameMgr.Instance.HourseMgr.Temphourse.Count; x++)
            {
                if (_housename == GameMgr.Instance.HourseMgr.Temphourse[x].name)
                {
                    GameMgr.Instance.HourseMgr.Temphourse[x].GetComponent<Hourse>().MyNpc.Add(_tempnpc);
                    GameMgr.Instance.HourseMgr.Temphourse[x].GetComponent<Hourse>().Inst();
                    break;
                }
            }
        }
    }
}
