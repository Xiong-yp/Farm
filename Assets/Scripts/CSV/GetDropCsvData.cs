using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDropCsvData : MonoBehaviour
{
    public struct MultDrop
    {
        public int id;
        public string name;
        public string picture;
        public string modle;
        public string info;
        public int overlay;
        public int minget;
        public int maxget;
        public int buyprice;
        public int saleprice;
    }
    public Dictionary<int, MultDrop> multiDropTable = new Dictionary<int, MultDrop>();

    string[][] Array;
    public void Inst()
    {
        TextAsset binAsset = Resources.Load("CSV/Drop") as TextAsset;
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
    string _picture;
    string _modle;
    string _info;
    int _overlay;
    int _minget;
    int _maxget;
    int _buyprice;
    int _saleprice;

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
                    _picture = m_array[i][j];
                }
                if (j == 3)
                {
                    _modle = m_array[i][j];
                }
                if (j == 4)
                {
                    _info = m_array[i][j];
                }
                if (j == 5)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _overlay = int.Parse(tempid);
                }
                if (j == 6)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _minget = int.Parse(tempid);
                }
                if (j == 7)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _maxget = int.Parse(tempid);
                }
                if (j == 8)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _buyprice = int.Parse(tempid);
                }
                if (j == 9)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _saleprice = int.Parse(tempid);
                }
            }
        }
    }
}
