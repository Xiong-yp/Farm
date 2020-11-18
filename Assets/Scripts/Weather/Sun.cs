using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float _rotateSpeed=10f;//昼夜变换速度（平行光旋转速度）
    public float _dayRadio=0.2f;//昼夜比增值（让白天更长）
    public int _sunStart;//太阳（平行光）初始角度
    
    public Light _sunLight;
    private float _radio;//太阳光亮度比重值（三角函数值）
    private float _sunIntensity;//太阳光强度比重

    public float _sunPower=10f;//太阳光亮度
    private void Awake()
    {
       
        /*_sunStart = Random.Range(0, 360);
        _sunLight =gameObject.GetComponent<Light>();
        gameObject.transform.Rotate(new Vector3(_sunStart, 0, 0));
        _radio = Mathf.Asin(transform.rotation.x / Mathf.Rad2Deg);
        _sunIntensity =_radio +_dayRadio;
        _sunLight.intensity = _sunIntensity*_sunPower;*/

      


    }

    private void Update()
    {
        gameObject.transform.Rotate(new Vector3(_rotateSpeed * Time.deltaTime, 0, 0));

        _radio = Mathf.Asin(transform.rotation.x / Mathf.Rad2Deg);

        _sunIntensity = _radio + _dayRadio;
        if (_sunIntensity < 0)
        {
            
            _sunIntensity = 0;
        }
        _sunLight.intensity = _sunIntensity * _sunPower;



      


    }
}
