using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera _vcam;
    private Transform _player;

    //镜头转向阻力，控制镜头平滑
    [SerializeField,Header("镜头平滑")] private float YawDamping = 20f;

    private Vector3 AimOffset;      //中心点偏移
    private Vector3 camOffset;      //相机位置偏移

    //相机左右偏移速度
    [SerializeField]
    private float _maxYOffsetSpeed;
    [SerializeField]
    private Vector2 _Offset;
    
    private bool isfollow;
    
    public void Init()
    {
        _vcam = GameMgr.Instance.mainCamera.transform.Find("PlayerCam").GetComponent<CinemachineVirtualCamera>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        isfollow = true;
        camOffset = new Vector3(0,15,-15);
        AimOffset = new Vector3(0,3,0);
    }

    void CinemachineInit()
    {
        
    }
    
    private void Update()
    {
        if (isfollow)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        _Offset = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
    }
}