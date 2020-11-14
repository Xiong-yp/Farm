using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMgr : MonoBehaviour
{
    private Transform _player;
    private Dictionary<int,CinemachineVirtualCamera> _camGroup;
    private List<float> camInitFiel;
    
    private const int maxPriority = 15;
    
    [Range(20,80)]
    private float PlayerZoomMaxSize;
    
    public enum CameraState
    {
        PlayerCam=0,
        BuildCam
    }
    private CameraState curCame;  //当前使用的虚拟相机
    private CinemachineFollowZoom _cueZoom;
    private const float ZoomSpeed = 40f;

    public void Init()
    {
        _camGroup =new Dictionary<int, CinemachineVirtualCamera>();
        camInitFiel=new List<float>();
        
        _player=_player = GameObject.FindGameObjectWithTag("Player").transform;
        List<CinemachineVirtualCamera> tempGroup = GameMgr.Instance.gameObject.transform
            .Find("CamGroup")
            .GetComponentsInChildren<CinemachineVirtualCamera>().ToList();
        int index = 0;
        foreach (CinemachineVirtualCamera cam in tempGroup)
        {
            _camGroup.Add(index,cam);
            _camGroup[index].Priority = index;
            camInitFiel.Add(_camGroup[index].GetComponent<CinemachineFollowZoom>().m_MinFOV);
            index++;
        }
        curCame = CameraState.PlayerCam;
        _camGroup[(int) curCame].Priority = maxPriority;
        _cueZoom = _camGroup[(int) curCame].GetComponent<CinemachineFollowZoom>();
    }

    private void Update()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        zoom = zoom * ZoomSpeed;
        Debug.Log(zoom);
        _cueZoom.m_MinFOV = Mathf.Clamp(_cueZoom.m_MinFOV + zoom, 20f, 90f);
    }

    
    

    //镜头切换测试
    IEnumerator ab()
    {
        yield return new WaitForSeconds(1f);
        ChangeCam(CameraState.BuildCam);
    }
    
    //镜头切换
    public void ChangeCam(CameraState _camState)
    {
        _camGroup[(int) _camState].Priority = maxPriority;
        _camGroup[(int) curCame].Priority = (int) curCame;
        curCame = _camState;
    }
}
