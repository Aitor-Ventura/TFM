using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] private GameObject _pickUpDrop;
    [SerializeField] private int _dropCount = 5;
    [SerializeField] private float _spread = 0.7f;
    
    public override void Hit()
    {
        for (int i = 0; i < _dropCount; i++)
        {
            Vector3 dropPos = new Vector3(transform.position.x + Random.Range(-_spread, _spread), transform.position.y + Random.Range(-_spread, _spread), transform.position.z);
            GameObject drop = Instantiate(_pickUpDrop, dropPos, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
