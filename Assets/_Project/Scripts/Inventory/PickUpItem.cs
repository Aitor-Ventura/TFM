using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUpItem : MonoBehaviour
{
    public Item item;
    public int count = 1;
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private float pickUpDistance = 1.5f;
    [SerializeField] private float timeToLeave = 10f;

    private Transform _player;

    private void Start()
    {
        _player = GameManager.Instance.player.transform;
    }

    public void SetItem(Item item, int count)
    {
        this.item = item;
        this.count = count;
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.icon;
    }

    private void Update()
    {
        ManageDespawn();
        MoveToPlayer();
    }

    private void ManageDespawn()
    {
        timeToLeave -= Time.deltaTime;
        if (timeToLeave < 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void MoveToPlayer()
    {
        float distance = Vector3.Distance(transform.position, _player.position);
        if (distance > pickUpDistance)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
        
        if (distance < 0.1f)
        {
            if (GameManager.Instance.inventoryContainer != null)
            {
                GameManager.Instance.inventoryContainer.AddItem(item, count);
            }
            else
            {
                Debug.LogWarning("No inventory has been found. Please attach an inventory to the GameManager.");
            }
            Destroy(gameObject);
        }
    }
}
