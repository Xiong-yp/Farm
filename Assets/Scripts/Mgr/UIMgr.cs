using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    private Dictionary<string, GameObject> UIGroup;
    private Transform UIparent;
    
    private GameObject _mask;
    
    public const string shopUI = "ShopUI";
    public const string TalkUI = "TalkUI";
    private const string path = "Prefabs/UI/";

    public void Init()
    {
        UIGroup = new Dictionary<string, GameObject>();
        UIparent = transform.Find("UIMgr");
        _mask=UIparent.Find("Mask").gameObject;
        _mask.SetActive(false);
        LoadUI();
        
        //test
        //ShowUI(shopUI);
        ShowUI(TalkUI);
    }

    public void LoadUI()
    {
        UIGroupAdd(shopUI);
        UIGroupAdd(TalkUI);
    }

    private void UIGroupAdd(string _name)
    {
        GameObject tempUI = Resources.Load($"{path}{_name}")as GameObject;
        tempUI = Instantiate(tempUI, UIparent);
        UIGroup.Add(_name,tempUI);
    }
    
    public void ShowUI(string _uiName,bool isMask=true)
    {
        _mask.SetActive(isMask);
        RectTransform _rect = UIGroup[_uiName].GetComponent<RectTransform>();
        _rect.localScale = new Vector3(0,0,1);
        _rect.gameObject.SetActive(true);
        _rect.DOScale(new Vector3(1f, 1f, 1), 0.5f)
            .SetEase(Ease.InQuad);
    }
    
    public void ShowUI(GameObject obj,bool isMask=true)
    {
        if(_mask!=null)
        _mask.SetActive(isMask);
        RectTransform _rect = obj.GetComponent<RectTransform>();
        _rect.localScale = new Vector3(0,0,1);
        _rect.gameObject.SetActive(true);
        _rect.DOScale(new Vector3(1f, 1f, 1), 0.5f)
            .SetEase(Ease.InQuad);
    }

    public void HideUI(string _uiName,bool isMask=false)
    {
        RectTransform _rect = UIGroup[_uiName].GetComponent<RectTransform>();
        _rect.DOScale(new Vector3(0f, 0f, 1), 0.5f)
            .OnComplete(delegate
            {
                _rect.gameObject.SetActive(false);
                if (_mask != null)
                {
                    _mask.SetActive(isMask);
                }
            });
    }
}
