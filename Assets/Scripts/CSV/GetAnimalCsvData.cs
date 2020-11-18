using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAnimalCsvData : MonoBehaviour
{
    public struct MultAnimal
    {
        public int id;
        public string name;
        public string modle;
        public string info;
        public int mingrowth;
        public int maxgrowth;
        public int minattack;
        public int maxattack;
        public int minhealth;
        public int maxhealth;
        public int minrunspeed;
        public int maxrunspeed;
        public int minattackspeed;
        public int maxattackspeed;
        public int minproduction;
        public int maxproduction;
        public string product;
        public int buyprice;
        public int saleprice;
    }
    public Dictionary<int, MultAnimal> multiAnimalTable = new Dictionary<int, MultAnimal>();

    string[][] Array;
    public void Inst()
    {
        TextAsset binAsset = Resources.Load("CSV/Animal") as TextAsset;
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
    string _info;
    int _mingrowth;
    int _maxgrowth;
    int _minattack;
    int _maxattack;
    int _minhealth;
    int _maxhealth;
    int _minrunspeed;
    int _maxrunspeed;
    int _minattackspeed;
    int _maxattackspeed;
    int _minproduction;
    int _maxproduction;
    string _product;
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
                    _modle = m_array[i][j];
                }
                if (j == 3)
                {
                    _info = m_array[i][j];
                }
                if (j == 4)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _mingrowth = int.Parse(tempid);
                }
                if (j == 5)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _maxgrowth = int.Parse(tempid);
                }
                if (j == 6)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _minattack = int.Parse(tempid);
                }
                if (j == 7)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _maxattack = int.Parse(tempid);
                }
                if (j == 8)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _minhealth = int.Parse(tempid);
                }
                if (j == 9)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _maxhealth = int.Parse(tempid);
                }
                if (j == 10)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _minrunspeed = int.Parse(tempid);
                }
                if (j == 11)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _maxrunspeed = int.Parse(tempid);
                }
                if (j == 12)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _minattackspeed = int.Parse(tempid);
                }
                if (j == 13)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _maxattackspeed = int.Parse(tempid);
                }
                if (j == 14)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _minproduction = int.Parse(tempid);
                }
                if (j == 15)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _maxproduction = int.Parse(tempid);
                }
                if (j == 16)
                {
                    _product = m_array[i][j];
                }
                if (j == 17)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _buyprice = int.Parse(tempid);
                }
                if (j == 18)
                {
                    string tempid = m_array[i][j];
                    tempid = tempid.Replace("\n", "");
                    _saleprice = int.Parse(tempid);
                }
            }
        }
    }
}
