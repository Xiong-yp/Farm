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
        public float overlay;
        public float minget;
        public float maxget;
        public float buyprice;
        public float saleprice;
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
    float _overlay;
    float _minget;
    float _maxget;
    float _buyprice;
    float _saleprice;

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
            MultDrop m_str = new MultDrop();
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
                    string tempoverlay = m_array[i][j];
                    tempoverlay = tempoverlay.Replace("\n", "");
                    _overlay = float.Parse(tempoverlay);
                }
                if (j == 6)
                {
                    string tempminget = m_array[i][j];
                    tempminget = tempminget.Replace("\n", "");
                    _minget = float.Parse(tempminget);
                }
                if (j == 7)
                {
                    string tempmaxget = m_array[i][j];
                    tempmaxget = tempmaxget.Replace("\n", "");
                    _maxget = float.Parse(tempmaxget);
                }
                if (j == 8)
                {
                    string tempbuyprice = m_array[i][j];
                    tempbuyprice = tempbuyprice.Replace("\n", "");
                    _buyprice = float.Parse(tempbuyprice);
                }
                if (j == 9)
                {
                    string tempsaleprice = m_array[i][j];
                    tempsaleprice = tempsaleprice.Replace("\n", "");
                    _saleprice = float.Parse(tempsaleprice);
                }
                m_str.id = _id;
                m_str.name = _name;
                m_str.picture = _picture;
                m_str.modle = _modle;
                m_str.info = _info;
                m_str.overlay = _overlay;
                m_str.minget = _minget;
                m_str.maxget = _maxget;
                m_str.buyprice = _buyprice;
                m_str.saleprice = _saleprice;
            }
        }
    }
}
