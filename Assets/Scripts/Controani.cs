using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controani : MonoBehaviour
{
    Animator _ani;
    NavMeshAgent _agen;
    NavMeshObstacle _obstacle;
    float max_x;
    float min_x;
    float max_z;
    float min_z;
    Vector3 _target;
    float tis;
    float dis;
    private void Awake()
    {
        _ani = transform.GetComponent<Animator>();
        _agen = transform.GetComponent<NavMeshAgent>();
        _obstacle = transform.GetComponent<NavMeshObstacle>();
        max_x = transform.localPosition.x + 10;
        min_x = transform.localPosition.x - 10;
        max_z = transform.localPosition.z + 10;
        min_z = transform.localPosition.z - 10;
    }
    void Pos()
    {
        _target = new Vector3(Random.Range(min_x, max_x), 0, Random.Range(min_z, max_z));
    }
    void isagent()
    {
        _agen.enabled = true;
        _agen.destination = _target;
    }
    void Arrive()
    {
        tis = dis;
        dis = Vector3.Distance(transform.localPosition, _target);
        if (tis != dis)
        {
            if (!_agen.isActiveAndEnabled && _obstacle.isActiveAndEnabled)
            {
                _obstacle.enabled = false;
                Invoke("isagent", 0.1f);
            }
            _ani.SetBool("grooming", false);
            _ani.SetBool("walk", true);
        }
        if (_agen.pathStatus == NavMeshPathStatus.PathComplete && !_agen.hasPath && !_agen.pathPending && _agen.remainingDistance < 1f)
        {
            if (_agen.isActiveAndEnabled)
            {
                _agen.enabled = false;
                _obstacle.enabled = true;
            }

        }
        //else
        //{
        //    //_ani.SetBool("grooming", false);
        //    //_ani.SetBool("walk", true);
        //}
        if (_agen.hasPath && _agen.remainingDistance < 1f)
        {
            if (_agen.isActiveAndEnabled)
            {
                _agen.enabled = false;
                _obstacle.enabled = true;
            }
            _ani.SetBool("grooming", true);
            _ani.SetBool("walk", false);

        }
    }
    private void Start()
    {
        InvokeRepeating("Pos", 0, 10f);
    }
    void Update()
    {
        Arrive();
    }
}
