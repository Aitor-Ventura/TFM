using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HighlightController : MonoBehaviour
{
    [SerializeField] private GameObject highlighter;

    private GameObject _currentTarget;
    
    public void Highlight(GameObject target)
    {
        if (_currentTarget == target) return;
        
        _currentTarget = target;
        Vector3 position = target.transform.position + Vector3.up * 0.5f; 
        Highlight(position);
    }
    
    public void Highlight(Vector3 position)
    {
        highlighter.SetActive(true);
        highlighter.transform.position = position;
    }
    
    public void Hide()
    {
        _currentTarget = null;
        highlighter.SetActive(false);
    }
}
