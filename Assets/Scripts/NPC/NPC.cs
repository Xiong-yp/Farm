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
    float _startwork;
    float _endwork;
    string _speack;
    float _attack;
    float _attackspeed;
    float _runspeed;
    float _health;
    float _brutal;
    float _price;


    public float Startwork { get => _startwork; set => _startwork = value; }
    public float Endwork { get => _endwork; set => _endwork = value; }
    public Hourse Temphpurse { get => _temphpurse; set => _temphpurse = value; }


    public void Inst(int id, string name, string modle, string professional, string housename,
        string tradable, float startwork, float endwork, string speack, float attack, float attackspeed, float runspeed, float health, float brutal, float price)
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
        _attack = attack;
        _attackspeed = attackspeed;
        _runspeed = runspeed;
        _health = health;
        _brutal = brutal;
        _price = price;
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

    }
    private void OnEnable()
    {
        Eventsys.GrowthTime += Pos;
        max_x = _temphpurse.transform.position.x + 20;
        min_x = _temphpurse.transform.position.x - 20;
        max_z = _temphpurse.transform.position.z + 20;
        min_z = _temphpurse.transform.position.z - 20;
        _target = new Vector3(Random.Range(min_x, max_x), 0, Random.Range(min_z, max_z));
        if (_agen.isActiveAndEnabled)
            _agen.destination = _target;
    }
    private void OnDisable()
    {
        Eventsys.GrowthTime -= Pos;
    }
    void Pos(float _nowtime)
    {
        if (_nowtime >= Startwork && _nowtime < Endwork)
        {
            _target = new Vector3(Random.Range(min_x, max_x), 0, Random.Range(min_z, max_z));
        }
        else if (_nowtime >= Endwork)
        {
            _target = Temphpurse.transform.Find("Pos").position;
        }
        if (!_agen.isActiveAndEnabled && _obstacle.isActiveAndEnabled)
        {
            _obstacle.enabled = false;
            Invoke("isagent", 0.1f);
        }
        else if (_agen.isActiveAndEnabled)
            _agen.destination = _target;
    }
    void isagent()
    {
        _agen.enabled = true;
        if (_agen.isActiveAndEnabled)
            _agen.destination = _target;
    }
    void Arrive()
    {
        tis = dis;
        dis = Vector3.Distance(_temphpurse.transform.position, _target);
        if (tis != dis)
        {
            if (!_agen.isActiveAndEnabled && _obstacle.isActiveAndEnabled)
            {
                _obstacle.enabled = false;
                Invoke("isagent", 0.1f);
            }
            //_ani.SetBool("grooming", false);
            _ani.SetFloat("Speed_f", 0.5f);
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
            _ani.SetFloat("Speed_f", 0);

        }
    }

    void SetHomePos()
    {
        if (GameMgr.Instance.TimeMgr._Time >= Endwork)
        {
            if (gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
                CancelInvoke("SetHomePos");
            }
        }
    }
    void Update()
    {
        Arrive();

    }
}
