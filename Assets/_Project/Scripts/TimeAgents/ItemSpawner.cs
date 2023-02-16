using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(TimeAgent))]
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int dropCount;
    [SerializeField] private float spread = 2f;
    [SerializeField] private float probability = 0.5f;

    private void Start()
    {
        TimeAgent timeAgent = GetComponent<TimeAgent>();
        timeAgent.onTimeTick += Spawn;
    }

    private void Spawn(){
        if (Random.value < probability)
        {
            Vector3 dropPos = new Vector3(transform.position.x + Random.Range(-spread, spread), transform.position.y + Random.Range(-spread, spread), transform.position.z);
            ItemSpawnManager.Instance.SpawnItem(dropPos, item, dropCount);
        }
    }
}
