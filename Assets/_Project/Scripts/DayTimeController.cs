using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] private Color _nightLightColor;
    [SerializeField] private Color _dayLightColor = Color.white;
    [SerializeField] private AnimationCurve _nightTimeCurve;
    [SerializeField] private float _timeScale = 60f;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Light2D _globalLight;
    
    private const float SECONDS_IN_DAY = 86400f;
    private float currentTime;
    private int days;
    
    public float Hours => currentTime / 3600f;
    public float Minutes => (currentTime % 3600f) / 60f;

    private void Update()
    {
        currentTime += Time.deltaTime * _timeScale;

        int hh = (int) Hours;
        int mm = (int) Minutes;
        
        _text.SetText(hh.ToString("00") + ":" + mm.ToString("00"));
        
        _globalLight.color = Color.Lerp(_dayLightColor, _nightLightColor, _nightTimeCurve.Evaluate(Hours));

        if (currentTime > SECONDS_IN_DAY)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        currentTime = 0;
        days += 1;
    }
}
