using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TreeCuttable : ToolHit
{
    [SerializeField] private GameObject pickUpDrop;
    [SerializeField] private float spread = 0.7f;
    
    [SerializeField] private Item item;
    [SerializeField] private int dropCount = 5;
    [SerializeField] private int itemCountInOneDrop = 1;
    
    public override void Hit()
    {
        for (int i = 0; i < dropCount; i++)
        {
            Vector3 dropPos = new Vector3(transform.position.x + Random.Range(-spread, spread), transform.position.y + Random.Range(-spread, spread), transform.position.z);
            
            ItemSpawnManager.Instance.SpawnItem(dropPos, item, itemCountInOneDrop);
        }
        
        Destroy(gameObject);
    }
}
