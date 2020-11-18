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
            MultAnimal m_str = new MultAnimal();
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
                    string tempmingrowth = m_array[i][j];
                    tempmingrowth = tempmingrowth.Replace("\n", "");
                    _mingrowth = int.Parse(tempmingrowth);
                }
                if (j == 5)
                {
                    string tempmaxgrowth = m_array[i][j];
                    tempmaxgrowth = tempmaxgrowth.Replace("\n", "");
                    _maxgrowth = int.Parse(tempmaxgrowth);
                }
                if (j == 6)
                {
                    string tempminattack = m_array[i][j];
                    tempminattack = tempminattack.Replace("\n", "");
                    _minattack = int.Parse(tempminattack);
                }
                if (j == 7)
                {
                    string tempmaxattack = m_array[i][j];
                    tempmaxattack = tempmaxattack.Replace("\n", "");
                    _maxattack = int.Parse(tempmaxattack);
                }
                if (j == 8)
                {
                    string tempminhealth = m_array[i][j];
                    tempminhealth = tempminhealth.Replace("\n", "");
                    _minhealth = int.Parse(tempminhealth);
                }
                if (j == 9)
                {
                    string tempmaxhealth = m_array[i][j];
                    tempmaxhealth = tempmaxhealth.Replace("\n", "");
                    _maxhealth = int.Parse(tempmaxhealth);
                }
                if (j == 10)
                {
                    string tempminrunspeed = m_array[i][j];
                    tempminrunspeed = tempminrunspeed.Replace("\n", "");
                    _minrunspeed = int.Parse(tempminrunspeed);
                }
                if (j == 11)
                {
                    string tempmaxrunspeed = m_array[i][j];
                    tempmaxrunspeed = tempmaxrunspeed.Replace("\n", "");
                    _maxrunspeed = int.Parse(tempmaxrunspeed);
                }
                if (j == 12)
                {
                    string tempminattackspeed = m_array[i][j];
                    tempminattackspeed = tempminattackspeed.Replace("\n", "");
                    _minattackspeed = int.Parse(tempminattackspeed);
                }
                if (j == 13)
                {
                    string tempmaxattackspeed = m_array[i][j];
                    tempmaxattackspeed = tempmaxattackspeed.Replace("\n", "");
                    _maxattackspeed = int.Parse(tempmaxattackspeed);
                }
                if (j == 14)
                {
                    string tempminproduction = m_array[i][j];
                    tempminproduction = tempminproduction.Replace("\n", "");
                    _minproduction = int.Parse(tempminproduction);
                }
                if (j == 15)
                {
                    string tempmaxproduction = m_array[i][j];
                    tempmaxproduction = tempmaxproduction.Replace("\n", "");
                    _maxproduction = int.Parse(tempmaxproduction);
                }
                if (j == 16)
                {
                    _product = m_array[i][j];
                }
                if (j == 17)
                {
                    string tempbuyprice = m_array[i][j];
                    tempbuyprice = tempbuyprice.Replace("\n", "");
                    _buyprice = int.Parse(tempbuyprice);
                }
                if (j == 18)
                {
                    string tempsaleprice = m_array[i][j];
                    tempsaleprice = tempsaleprice.Replace("\n", "");
                    _saleprice = int.Parse(tempsaleprice);
                }
                m_str.id = _id;
                m_str.name = _name;
                m_str.modle = _modle;
                m_str.info = _info;
                m_str.mingrowth = _mingrowth;
                m_str.maxgrowth = _maxgrowth;
                m_str.minattack = _minattack;
                m_str.maxattack = _maxattack;
                m_str.minhealth = _minhealth;
                m_str.maxhealth = _maxhealth;
                m_str.minrunspeed = _minrunspeed;
                m_str.maxrunspeed = _maxrunspeed;
                m_str.minproduction = _minproduction;
                m_str.maxproduction = _maxproduction;
                m_str.minattackspeed = _minattackspeed;
                m_str.maxattackspeed = _maxattackspeed;
                m_str.product = _product;
                m_str.buyprice = _buyprice;
                m_str.saleprice = _saleprice;
            }
            multiAnimalTable.Add(_id, m_str);
        }
    }
}
