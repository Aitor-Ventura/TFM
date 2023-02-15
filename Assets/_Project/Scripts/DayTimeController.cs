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
    private const float TIMEAGENT_CHUNK_TIME = 900f;
    
    private float _currentTime;
    
    private int _oldPhase;
    private int _days;

    private List<TimeAgent> _timeAgents;
    
    public float Hours => _currentTime / 3600f;
    public float Minutes => (_currentTime % 3600f) / 60f;


    private void Awake()
    {
        _timeAgents = new List<TimeAgent>();
    }

    private void Start()
    {
        _currentTime = 28800f;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime * timeScale;

        SetTimeAndDaylightColor();

        if (_currentTime > SECONDS_IN_DAY)
        {
            NextDay();
        }
        
        InvokeTimeAgents();
    }

    private void InvokeTimeAgents()
    {
        int currentPhase = (int) (_currentTime / TIMEAGENT_CHUNK_TIME);
        
        if (_oldPhase == currentPhase) return;
        
        _oldPhase = currentPhase;
        
        foreach (TimeAgent timeAgent in _timeAgents)
        {
            timeAgent.Invoke();
        }
    }

    private void SetTimeAndDaylightColor()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;

        text.SetText(hh.ToString("00") + ":" + mm.ToString("00"));
        
        globalLight.color = Color.Lerp(dayLightColor, nightLightColor, nightTimeCurve.Evaluate(Hours));
    }

    private void NextDay()
    {
        _currentTime = 0;
        _days += 1;
    }

    public void Subscribe(TimeAgent timeAgent)
    {
        _timeAgents.Add(timeAgent);
    }
    
    public void Unsubscribe(TimeAgent timeAgent)
    {
        _timeAgents.Remove(timeAgent);
    }
}
