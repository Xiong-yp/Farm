using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    Rigidbody _rig;
    private void Start()
    {
        _rig= gameObject.AddComponent<Rigidbody>();
        _rig.isKinematic = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            other.GetComponent<NPC>().InvokeRepeating("SetHomePos", 0, 5);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            other.GetComponent<NPC>().CancelInvoke("SetHomePos");  
        }
    }
}
