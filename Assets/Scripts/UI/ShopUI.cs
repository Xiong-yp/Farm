using System;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : UIBase
{
    private RectTransform _self;
    
    private Button _closebtn;
    private Button _nextbtn;
    private Button _previousbtn;
    
    private GameObject _buildiconSeed;
    
    //private Dictionary<string, Dictionary<Image, int>> _builds;
    private Dictionary<string, GameObject> _builds;
    private List<Toggle> _pageToggles;
    private int _pageIndex;

    private Transform _buildgroup;
    
    
    private void Awake()
    {
        Execute();
        //Debug.Log(_closebtn.name);
        
    }

    public void InitDate()
    {
        
    }
    
    protected override void InitUI()
    {
        _self = GetComponent<RectTransform>();
        
        _closebtn = transform.Find("BtnClose").GetComponent<Button>();
        _nextbtn = transform.Find("Btn_Next").GetComponent<Button>();
        _previousbtn = transform.Find("Btn_Previous").GetComponent<Button>();
        _buildgroup = transform.Find("BuildGroup");
        
        _pageToggles = transform.Find("PagesToggle").GetComponentsInChildren<Toggle>().ToList();
        _pageIndex = 0;

        _buildiconSeed = transform.Find("BuildIconSeed").gameObject;
    }

    protected override void AddEventListener()
    {
        _closebtn.onClick.AddListener(CloseSelf);
        _nextbtn.onClick.AddListener(delegate () { this.TurnPage(true); });
        _previousbtn.onClick.AddListener(delegate () { this.TurnPage(false); });
        _buildiconSeed.transform.Find("Btn_buy")
            .GetComponent<Button>().onClick.AddListener(BuildStruct);
    }

    void BuildStruct()
    {
         
    }
    
    void TurnPage(bool _isNext)
    {
        _pageIndex = _isNext ? (_pageIndex + 1)%_pageToggles.Count : (_pageIndex - 1)<0?_pageToggles.Count-1:(_pageIndex - 1);
        _pageToggles[_pageIndex].isOn = true;
    }
    
    private void CloseSelf()
    {
        _self.DOScale(new Vector3(0.1f, 0.1f, 1), 0.5f)
            .SetEase(Ease.InQuad)
            .OnComplete(delegate
        {
            gameObject.SetActive(false);
        });
    }

    protected override void RemoveEventListener()
    {
        
    }

    protected override void Dispose()
    {
        
    }
}
