using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMgr : MonoBehaviour
{
    public GameObject SelectObj;

    private Vector3 BuildPlaneSize;
    private Vector3 targetPos;
    
    [SerializeField]
    private bool isBuild=false;
    private bool canBuild;
    private GameObject IsBuildPlane;

    public void Init()
    {
        IsBuildPlane = transform.Find("HousePlane").gameObject;
    }
    
    private void Update()
    {
        if (isBuild)
        {
            SelectPos();
            
            if (Input.GetMouseButtonDown(0)) SetStruct();
        }
    }

    private void SelectPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane floor = new Plane(Vector3.up, Vector3.forward);
        float distToGround=0;
        if (floor.Raycast(ray,out distToGround))
        {
            Vector3 point = ray.GetPoint(distToGround);
            SelectObj.transform.position = point;
        }
    }

    public void OnSelectBuildStruct(GameObject _struct)
    {
        SelectObj = Instantiate(_struct);
        BoxCollider col = SelectObj.GetComponent<BoxCollider>();
        HouseTrigger _ht = SelectObj.AddComponent<HouseTrigger>();
        
        BuildPlaneSize = new Vector3(col.size.x,col.size.z,1);
        targetPos = col.center;
        targetPos.y = 0.1f;
        IsBuildPlane.transform.SetParent(SelectObj.transform);
        IsBuildPlane.transform.localPosition = targetPos;
        IsBuildPlane.transform.localScale = BuildPlaneSize;
        isBuild = true;
    }

    public void SetStruct()
    {
        
    }
}
