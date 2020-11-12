using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Here cant Build Struct");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Here can Build Struct");
    }
}
