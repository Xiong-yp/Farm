using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    int _id;
    string _name;
    string _modle;
    string _professional;
    string _housename;
    string _tradable;
    int _startwork;
    int _endwork;
    string _speack;

    public int Startwork { get => _startwork; set => _startwork = value; }
    public int Endwork { get => _endwork; set => _endwork = value; }
    public Hourse Temphpurse { get => _temphpurse; set => _temphpurse = value; }

    public void Inst(int id, string name, string modle, string professional, string housename,
        string tradable, int startwork, int endwork, string speack)
    {
        _id = id;
        _name = name;
        _modle = modle;
        _professional = professional;
        _housename = housename;
        _tradable = tradable;
        Startwork = startwork;
        Endwork = endwork;
        _speack = speack;
    }

    Animator _ani;
    NavMeshAgent _agen;
    NavMeshObstacle _obstacle;
    Hourse _temphpurse;

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
        Eventsys.GrowthTime += Pos;
    }
    private void OnEnable()
    {
        max_x = transform.localPosition.x + 50;
        min_x = transform.localPosition.x - 50;
        max_z = transform.localPosition.z + 50;
        min_z = transform.localPosition.z - 50;
    }
    void Pos(float _nowtime)
    {
        if (gameObject.activeInHierarchy)
        {
            for (int i = 0; i < Temphpurse.MyNpc.Count; i++)
            {
                if (_nowtime > Startwork && _nowtime < Endwork - 3f)
                {
                    if (!Temphpurse.MyNpc[i].activeInHierarchy)
                    {
                        _target = new Vector3(Random.Range(min_x, max_x), 0, Random.Range(min_z, max_z));
                    }
                }
                else if (_nowtime > Endwork - 3f)
                {
                    _target = Temphpurse.transform.Find("Pos").position;
                }
            }
        }

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
            //_ani.SetBool("grooming", false);
            //_ani.SetBool("walk", true);
        }
        if (_agen.pathStatus == NavMeshPathStatus.PathComplete && !_agen.hasPath && !_agen.pathPending && _agen.remainingDistance < 1f)
        {
            if (_agen.isActiveAndEnabled)
            {
                _agen.enabled = false;
                _obstacle.enabled = true;
            }

        }
        if (_agen.hasPath && _agen.remainingDistance < 1f)
        {
            if (_agen.isActiveAndEnabled)
            {
                _agen.enabled = false;
                _obstacle.enabled = true;
            }
            //_ani.SetBool("grooming", true);
            //_ani.SetBool("walk", false);

        }
    }
    private void Start()
    {

    }
    void Update()
    {
        Arrive();
    }
}
