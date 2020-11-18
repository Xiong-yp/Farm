using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmilAni : MonoBehaviour
{

    private Transform _fan;//风车的风扇
    private Transform _pivot;//风车的轴
    public float _fanRotateSpeed;//风车风扇转速
    public float _pivotRotateSpeed;//风车轴承转速
    // Start is called before the first frame update
    private void Awake()
    {
        _pivot = transform.Find("Windmil_Top");
        _fan = transform.Find("Windmil_Top/Windmill_Blades");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _fan.Rotate(new Vector3(0, 0,_fanRotateSpeed * Time.deltaTime));
        _pivot.rotation = Quaternion.Euler(new Vector3(0,  (Mathf.PingPong(Time.time * _pivotRotateSpeed, 90) - 90),0));
        

    }
}
