using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    private Dictionary<string, GameObject> UIGroup;

    public GameObject _mask;
    
    private const string _shopUi = "ShopUI";

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        UIGroup = new Dictionary<string, GameObject>();
        _mask.SetActive(false);

        GameObject ShopUI = Resources.Load("Prefabs/UI/ShopUI")as GameObject;
        ShopUI = Instantiate(ShopUI,transform);
        UIGroup.Add(_shopUi,ShopUI);
        ShowUI(_shopUi);
    }
    
    public void ShowUI(string _uiName)
    {
        RectTransform _rect = UIGroup[_shopUi].GetComponent<RectTransform>();
        _rect.localScale = new Vector3(0,0,1);
        _rect.gameObject.SetActive(true);
        _rect.DOScale(new Vector3(1f, 1f, 1), 0.5f)
            .SetEase(Ease.InQuad);
    }

    public void HideUI(string _uiName)
    {
        RectTransform _rect = UIGroup[_shopUi].GetComponent<RectTransform>();
        _rect.DOScale(new Vector3(0.1f, 0.1f, 1), 0.5f)
            .SetEase(Ease.InQuad)
            .OnComplete(delegate
            {
                gameObject.SetActive(false);
            });
    }
}
