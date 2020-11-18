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
    private GameObject IsBuildPlane;
    private Material BuildPlaneColor;

    private Color trueColor;
    private Color falseColor;

    private HouseTrigger _ht;
    
    public void Init()
    {
        IsBuildPlane = transform.Find("HousePlane").gameObject;
        BuildPlaneColor = IsBuildPlane.GetComponent<MeshRenderer>().material;
        trueColor = new Color(102, 255, 144, 221)/255;
        falseColor = new Color(255, 7, 0, 121)/255;
    }
    
    private void Update()
    {
        if (isBuild)
        {
            SelectPos();
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
            if (Input.GetMouseButtonDown(0)) SetStruct(point);
        }
    }

    public void OnSelectBuildStruct(GameObject _struct)
    {
        SelectObj = Instantiate(_struct);
        BoxCollider col = SelectObj.GetComponent<BoxCollider>();
        _ht = SelectObj.AddComponent<HouseTrigger>();
        
        BuildPlaneSize = new Vector3(col.size.x,col.size.z,1);
        targetPos = col.center;
        targetPos.y = 0.1f;
        IsBuildPlane.transform.SetParent(SelectObj.transform);
        IsBuildPlane.transform.localPosition = targetPos;
        IsBuildPlane.transform.localScale = BuildPlaneSize;
        isBuild = true;
    }

    public void SetStruct(Vector3 _pos)
    {
        IsBuildPlane.SetActive(false);
        IsBuildPlane.transform.SetParent(GameMgr.Instance.transform);
        SelectObj.AddComponent<Rigidbody>().useGravity = false;
        Destroy(_ht);
        SelectObj = null;
        isBuild = false;
    }

    public void ChangePlaneColor(bool cbuild)
    {
        if(cbuild) BuildPlaneColor.color = trueColor;
        else BuildPlaneColor.color = falseColor;
    }
}
