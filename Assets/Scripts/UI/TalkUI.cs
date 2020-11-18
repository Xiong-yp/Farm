using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TalkUI : UIBase
{
    //data
    private string[] _selectstring;  //主角选择对话
    private string _talkstring;    //对话文本
    private string _merchantName;  //商人名字

    private List<Item> _goods;     //商品

    //view
    private Button _ShopBtn;       //进入商店界面按钮
    private TextMeshProUGUI _ShopText;
    
    private Button _backBtn;       //退出对话
    private TextMeshProUGUI _backText;

    private Image CharacterIcon;   //角色头像
    private TextMeshProUGUI _talkText; //对话框
    //private Text _talkText;
    private Button _talkTextBtn;
    [SerializeField]
    private float waitTime=0.5f; 
    
    protected override void InitUI()
    {
        _ShopBtn = transform.Find("ShopBtn").GetComponent<Button>();
        _ShopText = transform.Find("ShopBtn/Text").GetComponent<TextMeshProUGUI>();
        
        _backBtn = transform.Find("BackBtn").GetComponent<Button>();
        _backText = transform.Find("BackBtn/Text").GetComponent<TextMeshProUGUI>();
        
        _talkText = transform.Find("DialogBox/Text").GetComponent<TextMeshProUGUI>();
        _talkTextBtn = transform.Find("DialogBox").GetComponent<Button>();
        CharacterIcon = transform.Find("Icon").GetComponent<Image>();
        
        
        //test
        _selectstring = new[] {"Buy", "Bye"};
        _talkstring = "Hello,Guy!11111111111111111111111111111111111111111111111111111111111111111" +
                      "1111111111111111111";
        _talkText.text = "";
        _ShopText.text = _selectstring[0];    
        _backText.text = _selectstring[1];
    }

    void DateInit()
    {
        
    }

    IEnumerator ShowText()
    {
        Debug.Log(1);
        foreach (char a in _talkstring)
        {
            _talkText.text += a;
            yield return new WaitForSeconds(waitTime);
        }
        waitTime = 0;
    }

    protected override void AddEventListener()
    {
        _backBtn.onClick.AddListener(delegate { GameMgr.Instance.UIMgr.ShowUI(UIMgr.TalkUI); });
        _ShopBtn.onClick.AddListener(delegate
        {
            GameMgr.Instance.UIMgr.HideUI(UIMgr.TalkUI);
            GameMgr.Instance.UIMgr.ShowUI(UIMgr.shopUI);
        });
        _backBtn.onClick.AddListener(delegate {GameMgr.Instance.UIMgr.HideUI(UIMgr.TalkUI); });
        _talkTextBtn.onClick.AddListener(TalkBtnClick);
        
        //test
        StartCoroutine("ShowText");
    }

    protected override void RemoveEventListener()
    {
        _backBtn.onClick.RemoveAllListeners();
        _ShopBtn.onClick.RemoveAllListeners();
        _backBtn.onClick.RemoveAllListeners();
        _talkTextBtn.onClick.RemoveAllListeners();
    }

    void TalkBtnClick()
    {
        if (waitTime != 0)
        {
            StopCoroutine("ShowText");
            _talkText.text = _talkstring;
        }

        GameMgr.Instance.UIMgr.ShowUI(_ShopBtn.gameObject);
        GameMgr.Instance.UIMgr.ShowUI(_backBtn.gameObject);
    }
    
    
    protected override void Dispose()
    {
        
    }
}
