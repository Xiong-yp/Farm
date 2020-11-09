using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseTrigger : MonoBehaviour
{
    private Material _material;
    private Color _texture;
    
    private void Awake()
    {
        _material = GetComponentInChildren<MeshRenderer>().material;
        _texture = _material.GetColor("_Color");
        Debug.Log(_texture);
        _texture = new Color(102, 214, 80, 146)/255;
        _material.SetColor("_Color",_texture);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "House")
        {
            Debug.Log("OnTriggerEnter");
            _texture = new Color(229,91,55,146)/255;
            _material.SetColor("_Color",_texture);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        _texture = new Color(102, 214, 80, 146)/255;
        _material.SetColor("_Color",_texture);
    }
}
