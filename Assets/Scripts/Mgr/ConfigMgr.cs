using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigMgr : MonoBehaviour
{
    public GetNpcCsvData GetNpcCsvData
    {
        get;
        private set;
    }
    public GetDropCsvData GetDropCsvData
    {
        get;
        private set;
    }
<<<<<<< HEAD
=======
    public GetAnimalCsvData GetAnimalCsvData
    {
        get;
        private set;
    }
>>>>>>> master
    public void Inst()
    {
        GetNpcCsvData = gameObject.AddComponent<GetNpcCsvData>();
        GetNpcCsvData.Inst();

<<<<<<< HEAD
        //GetDropCsvData = gameObject.AddComponent<GetDropCsvData>();
        //GetDropCsvData.Inst();
=======
        GetDropCsvData = gameObject.AddComponent<GetDropCsvData>();
        GetDropCsvData.Inst();

        GetAnimalCsvData = gameObject.AddComponent<GetAnimalCsvData>();
        GetAnimalCsvData.Inst();
>>>>>>> master
    }
}
