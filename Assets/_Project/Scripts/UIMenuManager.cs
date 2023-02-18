using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup titleCanvasGroup;
    [SerializeField] private CanvasGroup clickToStartCanvasGroup;
    [SerializeField] private CanvasGroup creditsCanvasGroup;

    private bool _canClickCanvasGroups;

    private void Start()
    {
        Show();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canClickCanvasGroups)
        {
            _canClickCanvasGroups = false;
            Hide();
        }
    }

    private void Show()
    {
        titleCanvasGroup.DOFade(1f, 5f).From(0, true);
        clickToStartCanvasGroup.DOFade(1f, 1f).From(0, true).SetDelay(2f).SetLoops(-1, LoopType.Yoyo);
        creditsCanvasGroup.DOFade(1f, 5f).From(0, true).SetDelay(2f).OnPlay(() =>
        {
            _canClickCanvasGroups = true;
        });
    }

    private void Hide()
    {
        titleCanvasGroup.DOKill();
        clickToStartCanvasGroup.DOKill();
        creditsCanvasGroup.DOKill();
        
        titleCanvasGroup.DOFade(0f, 1f);
        clickToStartCanvasGroup.DOFade(0f, 1f);
        creditsCanvasGroup.DOFade(0f, 1f).OnComplete(() =>
        {
            SceneManager.LoadScene("GameplayScene");
        });
    }
}
