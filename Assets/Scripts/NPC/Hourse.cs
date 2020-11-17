using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourse : MonoBehaviour
{
    List<GameObject> _myNpc = new List<GameObject>();
    Transform _pos;
    public List<GameObject> MyNpc
    {
        get => _myNpc;
        set => _myNpc = value;
    }

    public void Inst()
    {
        Eventsys.GrowthTime += InstNpc;
        if (!_pos)
        {
            _pos = transform.Find("Pos");
            _pos.gameObject.AddComponent<GoHome>();

        }
    }
<<<<<<< HEAD
<<<<<<< HEAD
    Npc _temp;
=======
    NPC _temp;
>>>>>>> parent of f4197056 (1)
=======
    NPC _temp;
>>>>>>> parent of f4197056 (1)
    public void InstNpc(float _nowTime)
    {
        for (int i = 0; i < _myNpc.Count; i++)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            _temp = _myNpc[i].GetComponent<Npc>();
=======
            _temp = _myNpc[i].GetComponent<NPC>();
>>>>>>> parent of f4197056 (1)
=======
            _temp = _myNpc[i].GetComponent<NPC>();
>>>>>>> parent of f4197056 (1)
            if (_nowTime >= _temp.Startwork && _nowTime < _temp.Endwork)
            {
                if (!_myNpc[i].activeInHierarchy)
                {
                    _myNpc[i].transform.position = _pos.position;
                    _temp.Temphpurse = this;
                    _myNpc[i].SetActive(true);
                }
            }

        }
    }
}
