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

    public void Init()
    {
        UIGroup = new Dictionary<string, GameObject>();
        UIparent = transform.Find("UIMgr");
        _mask=UIparent.Find("Mask").gameObject;
        _mask.SetActive(false);

        GameObject ShopUI = Resources.Load("Prefabs/UI/ShopUI")as GameObject;
        ShopUI = Instantiate(ShopUI,UIparent);
        UIGroup.Add(shopUI,ShopUI);
        
        ShowUI(shopUI);
    }
    
    public void ShowUI(string _uiName)
    {
        RectTransform _rect = UIGroup[shopUI].GetComponent<RectTransform>();
        _rect.localScale = new Vector3(0,0,1);
        _rect.gameObject.SetActive(true);
        _rect.DOScale(new Vector3(1f, 1f, 1), 0.5f)
            .SetEase(Ease.InQuad);
    }

    public void HideUI(string _uiName)
    {
        RectTransform _rect = UIGroup[shopUI].GetComponent<RectTransform>();
        _rect.DOScale(new Vector3(0.1f, 0.1f, 1), 0.5f)
            .SetEase(Ease.InQuad)
            .OnComplete(delegate
            {
                _rect.gameObject.SetActive(false);
            });
    }
}
