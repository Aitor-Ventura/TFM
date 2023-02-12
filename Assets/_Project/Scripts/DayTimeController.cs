using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] private Color nightLightColor;
    [SerializeField] private Color dayLightColor = Color.white;
    [SerializeField] private AnimationCurve nightTimeCurve;
    [SerializeField] private float timeScale = 60f;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Light2D globalLight;
    
    private const float SECONDS_IN_DAY = 86400f;
    private float _currentTime;
    private int _days;
    
    public float Hours => _currentTime / 3600f;
    public float Minutes => (_currentTime % 3600f) / 60f;

    private void Update()
    {
        _currentTime += Time.deltaTime * timeScale;

        int hh = (int) Hours;
        int mm = (int) Minutes;
        
        text.SetText(hh.ToString("00") + ":" + mm.ToString("00"));
        
        globalLight.color = Color.Lerp(dayLightColor, nightLightColor, nightTimeCurve.Evaluate(Hours));

        if (_currentTime > SECONDS_IN_DAY)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        _currentTime = 0;
        _days += 1;
    }
}
