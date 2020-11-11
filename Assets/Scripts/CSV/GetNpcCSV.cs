using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNpcCSV : MonoBehaviour
{
    public struct Multinpc
    {
        public int id;
        public string name;
        public string modle;
        public string professional;
        public string housename;
        public string tradable;
        public string workhours;
        public string speack;
    }

    public Dictionary<int, Multinpc> multiNpcTable = new Dictionary<int, Multinpc>();

    string[][] Array;

    public void Inst()
    {
        TextAsset binAsset = Resources.Load("Npc/Npc") as TextAsset;
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
    string _workhours;
    string _speack;

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
            Multinpc m_str = new Multinpc();
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
                    _workhours = m_array[i][j];
                }
                if (j == 7)
                {
                    _speack = m_array[i][j];
                }
                m_str.id = _id;
                m_str.name = _name;
                m_str.modle = _modle;
                m_str.professional = _professional;
                m_str.housename = _housename;
                m_str.tradable = _tradable;
                m_str.workhours = _workhours;
                m_str.speack = _speack;
            }
            multiNpcTable.Add(_id, m_str);
        }
    }
    //public string GetStrByID(int id)
    //{
    //    if(multiNpcTable.ContainsKey(id))
    //    {
    //        if()
    //        {

    //        }
    //    }
    //}

}
