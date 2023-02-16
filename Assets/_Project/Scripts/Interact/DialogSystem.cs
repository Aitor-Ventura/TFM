using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image portraitImage;
    
    [Range(0f, 1f)]
    [SerializeField] private float visibleTextPercentage;

    [SerializeField] private float timePerLetter = 0.05f;

    private DialogContainer _currentDialog;
    private int _currentTextLine;

    private float _totalTimeToType;
    private float _currentTime;
    private string _lineToShow;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PushText();
        }

        TypeOutText();
    }

    private void UpdateText()
    {
        int letterCount = (int) (_lineToShow.Length * visibleTextPercentage);
        targetText.text = _lineToShow.Substring(0, letterCount);
    }

    private void TypeOutText()
    {
        if (visibleTextPercentage >= 1f) return;
        
        _currentTime += Time.deltaTime;
        
        visibleTextPercentage = _currentTime / _totalTimeToType;
        visibleTextPercentage = Mathf.Clamp(visibleTextPercentage, 0, 1f);

        UpdateText();
    }

    private void PushText()
    {
        if (visibleTextPercentage < 1f)
        {
            visibleTextPercentage = 1;
            UpdateText();
            return;
        }
        
        if (_currentTextLine >= _currentDialog.dialog.Count)
        {
            Conclude();
        }
        else
        {
            CycleLine();
        }
    }

    private void CycleLine()
    {
        _lineToShow = _currentDialog.dialog[_currentTextLine];
        _totalTimeToType = _lineToShow.Length * timePerLetter;
        _currentTime = 0f;
        visibleTextPercentage = 0f;
        targetText.text = "";
        
        _currentTextLine += 1;
    }
    
    private void Conclude()
    {
        Show(false);
    }

    public void Initialize(DialogContainer dialogContainer)
    {
        Show(true);
        _currentDialog = dialogContainer;
        _currentTextLine = 0;
        CycleLine();
        UpdatePortrait();
    }

    private void UpdatePortrait()
    {
        portraitImage.sprite = _currentDialog.actor.portrait;
        nameText.SetText(_currentDialog.actor.name);
    }

    private void Show(bool active)
    {
        gameObject.SetActive(active);
    }
}
