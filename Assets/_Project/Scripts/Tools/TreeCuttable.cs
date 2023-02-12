using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TreeCuttable : ToolHit
{
    [SerializeField] private GameObject _pickUpDrop;
    [SerializeField] private float _spread = 0.7f;

    [SerializeField] private Item _item;
    [SerializeField] private int _dropCount = 5;
    [SerializeField] private int _itemCountInOneDrop = 1;
    
    public override void Hit()
    {
        for (int i = 0; i < _dropCount; i++)
        {
            Vector3 dropPos = new Vector3(transform.position.x + Random.Range(-_spread, _spread), transform.position.y + Random.Range(-_spread, _spread), transform.position.z);
            
            ItemSpawnManager.Instance.SpawnItem(dropPos, _item, _itemCountInOneDrop);
        }
        
        Destroy(gameObject);
    }
}
