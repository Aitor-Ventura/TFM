using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] private GameObject _highlighter;

    private GameObject currentTarget;
    
    public void Highlight(GameObject target)
    {
        if (currentTarget == target) return;
        
        currentTarget = target;
        Vector3 position = target.transform.position + Vector3.up * 0.5f; 
        Highlight(position);
    }
    
    public void Highlight(Vector3 position)
    {
        _highlighter.SetActive(true);
        _highlighter.transform.position = position;
    }
    
    public void Hide()
    {
        currentTarget = null;
        _highlighter.SetActive(false);
    }
}
