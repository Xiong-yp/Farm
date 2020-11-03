using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _agent;
    Ray _ray;
    RaycastHit _hit;
    int _floorMask;
    float _camLength = 100f;
    Vector3 _moveTarget;
    Animator _ani;
    NavMeshObstacle _obstacle;
    float _dis;
    float _tis;
    private void Awake()
    {
        _agent = transform.GetComponent<NavMeshAgent>();
        _floorMask = LayerMask.GetMask("Floor");
        _ani = transform.GetComponent<Animator>();
        _obstacle = transform.GetComponent<NavMeshObstacle>();
    }
    void isagent()
    {
        _agent.enabled = true;
        if (Physics.Raycast(_ray, out _hit, _camLength, _floorMask))
        {
            _moveTarget = _hit.point;
            _agent.destination = _moveTarget;
        }
    }
    void PlayerMove()
    {
        _tis = _dis;
        _dis = Vector3.Distance(transform.localPosition, _moveTarget);
        if (_tis != _dis)
        {
            if (_obstacle.isActiveAndEnabled)
            {
                _obstacle.enabled = false;
                Invoke("isagent", 0.1f);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, _camLength, _floorMask))
            {
                _moveTarget = _hit.point;
                _agent.destination = _moveTarget;
                _ani.SetBool("idie", false);
                _ani.SetBool("run", true);
            }
        }
        if (_agent.pathStatus == NavMeshPathStatus.PathComplete && !_agent.hasPath && !_agent.pathPending && _agent.remainingDistance < 1f)
        {
            _ani.SetBool("idie", true);
            _ani.SetBool("run", false);
        }
        if (_agent.hasPath && _agent.remainingDistance < 1f)
        {
            if (_agent.isActiveAndEnabled)
            {
                _agent.enabled = false;
                _obstacle.enabled = true;
            }
            _ani.SetBool("idie", true);
            _ani.SetBool("run", false);
        }
    }
    void Update()
    {
        PlayerMove();
    }
}
