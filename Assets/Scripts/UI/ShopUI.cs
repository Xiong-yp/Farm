using System;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopUI : UIBase
{
    private RectTransform _self;
    
    private Button _closebtn;
    private Button _nextbtn;
    private Button _previousbtn;
    
    private GameObject _buildiconSeed;
    
    private Dictionary<string,GameObject> _builds;
    public GameObject build;
    private List<Toggle> _pageToggles;
    private int _pageIndex;

    private Transform _buildgroup;
    private UnityAction OnCloseUIClick;
    private UnityAction OnShowUIClick;

    private UnityAction OnBuildsBtnClick;
    
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
        //TO DO 可选建筑获取 Dic：_builds初始
        
        _pageToggles = transform.Find("PagesToggle").GetComponentsInChildren<Toggle>().ToList();
        _pageIndex = 0;

        _buildiconSeed = transform.Find("BuildIconSeed").gameObject;
    }
    
    protected override void AddEventListener()
    {
        OnCloseUIClick = delegate { GameMgr.Instance.UIMgr.HideUI(UIMgr.shopUI); };

        _closebtn.onClick.AddListener(OnCloseUIClick);
        _nextbtn.onClick.AddListener(NextPage);
        _previousbtn.onClick.AddListener(BackPage);
        
        //TO DO BuildGroup ADD Listener
        /*foreach (var VARIABLE in _builds)
        {
            _buildiconSeed.transform.Find("Btn_buy")
                    .GetComponent<Button>().onClick.AddListener();
        }*/
        
        //临时测试obj
        GameObject obj = Instantiate(_buildiconSeed,_buildgroup);
        OnBuildsBtnClick += delegate { BuildStruct("111"); };
        obj.SetActive(true);
        obj.transform.Find("Btn_buy")
            .GetComponent<Button>().onClick.AddListener(OnBuildsBtnClick);
    }

    void BuildStruct(string name)
    {
        //GameMgr.Instance.BuildMgr.OnSelectBuildStruct(_builds[name]);
        //test
        GameMgr.Instance.BuildMgr.OnSelectBuildStruct(build);
        GameMgr.Instance.UIMgr.HideUI(UIMgr.shopUI);
    }
    

    void BackPage()
    {
        _pageIndex = (_pageIndex + 1)%_pageToggles.Count;
        _pageToggles[_pageIndex].isOn = true;
    }

    void NextPage()
    {
        _pageIndex = (_pageIndex - 1)<0?_pageToggles.Count-1:(_pageIndex - 1);
        _pageToggles[_pageIndex].isOn = true;
    }
    
    protected override void RemoveEventListener()
    {
        _closebtn.onClick.RemoveAllListeners();
        _nextbtn.onClick.RemoveAllListeners();
        _previousbtn.onClick.RemoveAllListeners();
        
    }

    protected override void Dispose()
    {
        gameObject.SetActive(false);
    }
}
