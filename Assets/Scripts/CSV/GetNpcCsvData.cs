using System.Collections;
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
    float _startwork;
    float _endwork;
    string _speack;
    float _attack;
    float _attackspeed;
    float _runspeed;
    float _health;
    float _brutal;
    float _price;

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
                    string tempstartwork = m_array[i][j];
                    tempstartwork = tempstartwork.Replace("\n", "");
                    _startwork = float.Parse(tempstartwork);
                }
                if (j == 7)
                {
                    string tempendwork = m_array[i][j];
                    tempendwork = tempendwork.Replace("\n", "");
                    _endwork = float.Parse(tempendwork);
                }
                if (j == 8)
                {
                    _speack = m_array[i][j];
                }
                if (j == 9)
                {
                    string tempattack = m_array[i][j];
                    tempattack = tempattack.Replace("\n", "");
                    _attack = float.Parse(tempattack);
                }
                if (j == 10)
                {
                    string tempattackspeed = m_array[i][j];
                    tempattackspeed = tempattackspeed.Replace("\n", "");
                    _attackspeed = float.Parse(tempattackspeed);
                }
                if (j == 11)
                {
                    string temprunspeed = m_array[i][j];
                    temprunspeed = temprunspeed.Replace("\n", "");
                    _runspeed = float.Parse(temprunspeed);
                }
                if (j == 12)
                {
                    string temphealth = m_array[i][j];
                    temphealth = temphealth.Replace("\n", "");
                    _health = float.Parse(temphealth);
                }
                if (j == 13)
                {
                    string tempbrutal = m_array[i][j];
                    tempbrutal = tempbrutal.Replace("\n", "");
                    _brutal = float.Parse(tempbrutal);
                }
                if (j == 14)
                {
                    string tempprice = m_array[i][j];
                    tempprice = tempprice.Replace("\n", "");
                    _price = float.Parse(tempprice);
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
