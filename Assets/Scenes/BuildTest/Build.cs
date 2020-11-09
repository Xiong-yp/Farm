using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject HouseSeed;
    public GameObject TempHouse;
    
    private void Awake()
    {
        TempHouse = Instantiate(HouseSeed, Vector3.zero, Quaternion.identity);
        TempHouse.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.forward);
            float distToGround=0;
            if (plane.Raycast(ray,out distToGround))
            {
                Vector3 point = ray.GetPoint(distToGround);
                TempHouse.transform.position = point;
                //Debug.Log(point);
            }
        }
    }
}
