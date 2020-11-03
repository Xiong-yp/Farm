using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatTree : MonoBehaviour
{
    public GameObject[] _tree;
    public Transform _rang;
    public Transform _parent;
    public int j;
    GameObject _temp;
    Collider[] cs;
    [ContextMenu("cre")]
    void Creattree()
    {
        for(int i=0;i<j;i++)
        {
            _temp = Instantiate(_tree[Random.Range(0,_tree.Length)], _rang.TransformPoint(RandomFloat(), 0, RandomFloat()), Quaternion.identity, _parent);
            _temp.transform.position = new Vector3(_temp.transform.position.x, 0, _temp.transform.position.z);
            SetPos(_temp);
        }
    }
    float RandomFloat()
    {
        return Random.Range(-0.5f, 0.5f);
    }
    void SetPos(GameObject obj)
    {
        Collider[] cs = Physics.OverlapSphere(obj.transform.position, 0.5f, 1 << 8);
        if(cs.Length !=0)
        {
            foreach(Collider csCell in cs)
            {
                if(csCell.name !=obj.transform.name)
                {
                    obj.transform.position = _rang.TransformPoint(RandomFloat(), 0, RandomFloat());
                    SetPos(obj);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
