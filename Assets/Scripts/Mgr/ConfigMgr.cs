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
    public void Inst()
    {
        GetNpcCsvData = gameObject.AddComponent<GetNpcCsvData>();
        GetNpcCsvData.Inst();
    }
}
