using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMonsterCsvData : MonoBehaviour
{
    public struct MultMonster
    {
        public int id;
        public string name;
        public string modle;
        public float mingrowth;
        public float maxgrowth;
        public float minattack;
        public float maxattack;
        public float minhealth;
        public float maxhealth;
        public float minrunspeed;
        public float maxrunspeed;
        public float minattackspeed;
        public float maxattackspeed;
    }
    public Dictionary<int, MultMonster> multiMonsterTable = new Dictionary<int, MultMonster>();

    string[][] Array;
    public void Inst()
    {
        TextAsset binAsset = Resources.Load("CSV/Monster") as TextAsset;
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
    float _mingrowth;
    float _maxgrowth;
    float _minattack;
    float _maxattack;
    float _minhealth;
    float _maxhealth;
    float _minrunspeed;
    float _maxrunspeed;
    float _minattackspeed;
    float _maxattackspeed;

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
            MultMonster m_str = new MultMonster();
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
                    string tempmingrowth = m_array[i][j];
                    tempmingrowth = tempmingrowth.Replace("\n", "");
                    _mingrowth = float.Parse(tempmingrowth);
                }
                if (j == 4)
                {
                    string tempmaxgrowth = m_array[i][j];
                    tempmaxgrowth = tempmaxgrowth.Replace("\n", "");
                    _maxgrowth = float.Parse(tempmaxgrowth);
                }
                if (j == 5)
                {
                    string tempminattack = m_array[i][j];
                    tempminattack = tempminattack.Replace("\n", "");
                    _minattack = float.Parse(tempminattack);
                }
                if (j == 6)
                {
                    string tempmaxattack = m_array[i][j];
                    tempmaxattack = tempmaxattack.Replace("\n", "");
                    _maxattack = float.Parse(tempmaxattack);
                }
                if (j == 7)
                {
                    string tempminhealth = m_array[i][j];
                    tempminhealth = tempminhealth.Replace("\n", "");
                    _minhealth = float.Parse(tempminhealth);
                }
                if (j == 8)
                {
                    string tempmaxhealth = m_array[i][j];
                    tempmaxhealth = tempmaxhealth.Replace("\n", "");
                    _maxhealth = float.Parse(tempmaxhealth);
                }
                if (j == 9)
                {
                    string tempminrunspeed = m_array[i][j];
                    tempminrunspeed = tempminrunspeed.Replace("\n", "");
                    _minrunspeed = float.Parse(tempminrunspeed);
                }
                if (j == 10)
                {
                    string tempmaxrunspeed = m_array[i][j];
                    tempmaxrunspeed = tempmaxrunspeed.Replace("\n", "");
                    _maxrunspeed = float.Parse(tempmaxrunspeed);
                }
                if (j == 11)
                {
                    string tempminattackspeed = m_array[i][j];
                    tempminattackspeed = tempminattackspeed.Replace("\n", "");
                    _minattackspeed = float.Parse(tempminattackspeed);
                }
                if (j == 12)
                {
                    string tempmaxattackspeed = m_array[i][j];
                    tempmaxattackspeed = tempmaxattackspeed.Replace("\n", "");
                    _maxattackspeed = float.Parse(tempmaxattackspeed);
                }
                m_str.id = _id;
                m_str.name = _name;
                m_str.modle = _modle;
                m_str.mingrowth = _mingrowth;
                m_str.maxgrowth = _maxgrowth;
                m_str.minattack = _minattack;
                m_str.maxattack = _maxattack;
                m_str.minhealth = _minhealth;
                m_str.maxhealth = _maxhealth;
                m_str.minrunspeed = _minrunspeed;
                m_str.maxrunspeed = _maxrunspeed;
                m_str.minattackspeed = _minattackspeed;
                m_str.maxattackspeed = _maxattackspeed;
            }
            multiMonsterTable.Add(_id, m_str);
        }
    }
}
