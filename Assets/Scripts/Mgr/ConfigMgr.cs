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
    public GetAnimalCsvData GetAnimalCsvData
    {
        get;
        private set;
    }
<<<<<<< HEAD
=======

>>>>>>> master
    public GetMonsterCsvData GetMonsterCsvData
    {
        get;
        private set;
    }
<<<<<<< HEAD
=======
    public GetCommodityCsvData GetCommodityCsvData
    {
        get;
        private set;
    }
>>>>>>> master
    public void Inst()
    {
        GetNpcCsvData = gameObject.AddComponent<GetNpcCsvData>();
        GetNpcCsvData.Inst();

        GetDropCsvData = gameObject.AddComponent<GetDropCsvData>();
        GetDropCsvData.Inst();

        GetAnimalCsvData = gameObject.AddComponent<GetAnimalCsvData>();
        GetAnimalCsvData.Inst();

        GetMonsterCsvData = gameObject.AddComponent<GetMonsterCsvData>();
        GetMonsterCsvData.Inst();
<<<<<<< HEAD
=======

        GetCommodityCsvData = gameObject.AddComponent<GetCommodityCsvData>();
        GetCommodityCsvData.Inst();

>>>>>>> master
    }
}
