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
    public GameObject build;
    private List<Toggle> _pageToggles;
    private int _pageIndex;

    private Transform _buildgroup;
    
    
    private void Awake()
    {
        Execute();
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
        _closebtn.onClick.AddListener(delegate { GameMgr.Instance.UIMgr.HideUI(UIMgr.shopUI); });
        _nextbtn.onClick.AddListener(delegate () { this.TurnPage(true); });
        _previousbtn.onClick.AddListener(delegate () { this.TurnPage(false); });
        _buildiconSeed.transform.Find("Btn_buy")
            .GetComponent<Button>().onClick.AddListener(delegate { BuildStruct("111"); });
        
        //临时测试obj
        GameObject obj = Instantiate(_buildiconSeed,_buildgroup);
        obj.SetActive(true);
        obj.transform.Find("Btn_buy")
            .GetComponent<Button>().onClick.AddListener(delegate { BuildStruct("111"); });
    }

    void BuildStruct(string _struct)
    {
        //Debug.Log(1);
        GameMgr.Instance.BuildMgr.OnSelectBuildStruct(build);
        GameMgr.Instance.UIMgr.HideUI(UIMgr.shopUI);
    }
    
    void TurnPage(bool _isNext)
    {
        _pageIndex = _isNext ? (_pageIndex + 1)%_pageToggles.Count : (_pageIndex - 1)<0?_pageToggles.Count-1:(_pageIndex - 1);
        _pageToggles[_pageIndex].isOn = true;
    }

    protected override void RemoveEventListener()
    {
        
    }

    protected override void Dispose()
    {
        
    }
}
