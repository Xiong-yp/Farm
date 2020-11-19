using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightMgr : MonoBehaviour
{
    GameObject _SunDirLight;
    Light _sunDirLightSetiing;
    private float _sunAngle;//太阳（月亮）角度
    private float _sunLightIntensity;//阳光强度系数
    private float _sunLightPower=1.5f;//太阳光强度
    private float _MinSunlightIntensity=0.1f;//阳光最小强度系数
    private float _increaSunlightIntensity = 1.2f;//阳光增长强度系数
    private float _sunLightColorRate;//阳光颜色混合比例系数

    private Color32 _sunDirLightColor;
    private Color32 _nightSkyColor = new Color32(0, 0, 139,255);//夜光颜色（深蓝）
    private Color32 _risingSunColor = new Color32(255, 18, 137, 255);//朝阳颜色（紫罗兰红）
    private Color32 _sunsetColor = new Color32(238,64, 0, 255);//夕阳颜色（橘红色）
    private Color32 _daySunColor = new Color32(255, 244, 214, 255);//白天阳光颜色（小麦色）
  
    float _h;
    float _min;
    float _s;


    public void Inst()
    {
        _SunDirLight = transform.Find("SunDirLight").gameObject;
        _sunDirLightSetiing = _SunDirLight.GetComponent<Light>();

    
    }
    private void Update()
    {
        sunLightSetting();
    }

    private void sunLightSetting()
    {
        _h = GameMgr.Instance.TimeMgr._Hour;
        _min = GameMgr.Instance.TimeMgr._Min;
        _s = GameMgr.Instance.TimeMgr._Seconds;
        if (0 <= _h && _h<=6)
        {
            _sunAngle = 90 + _h * 15 + _min / 4 + _s / 240;
            _sunLightIntensity = _MinSunlightIntensity;
            _sunDirLightColor = _nightSkyColor;


        }
        if (6 <_h && _h < 18)
        {
            _sunAngle = (_h - 6) * 15 + _min / 4 + _s / 240;
            _sunLightIntensity = _MinSunlightIntensity + (Mathf.Sin((_h - 6) * 15 *Mathf.Deg2Rad))*_increaSunlightIntensity;
            if (6 < _h && _h <7)
            {
                _sunLightColorRate = Mathf.Sin(_min*Mathf.PI/120);
                _sunDirLightColor = Color32.Lerp(_nightSkyColor, _risingSunColor, _sunLightColorRate);
            }
            if (7 <= _h && _h < 8)
            {
                _sunLightColorRate = Mathf.Cos(_min*Mathf.PI/120);
                _sunDirLightColor = Color32.Lerp(_daySunColor, _risingSunColor,  _sunLightColorRate);

            }

           
            if (16 <= _h && _h < 17)
            {
                _sunLightColorRate = Mathf.Sin(_min*Mathf.PI/120);
                _sunDirLightColor = Color32.Lerp(_daySunColor, _sunsetColor, _sunLightColorRate);

            }
            if (17 <= _h && _h < 18)
            {
                _sunLightColorRate = Mathf.Cos(_min*Mathf.PI/120);
                _sunDirLightColor = Color32.Lerp(_nightSkyColor, _sunsetColor,_sunLightColorRate);
            }

        }
        if (18 <= _h && _h <=24)
        { 
         _sunAngle = (_h-18)*15 + _h * 15 + _min / 4 + _s / 240;
            _sunLightIntensity = _MinSunlightIntensity;
            _sunDirLightColor = _nightSkyColor;
        }

        _SunDirLight.transform.rotation = Quaternion.Euler(_sunAngle, 0, 0);
        _sunDirLightSetiing.intensity = _sunLightIntensity * _sunLightPower;
        _sunDirLightSetiing.color = _sunDirLightColor;

    }

}
