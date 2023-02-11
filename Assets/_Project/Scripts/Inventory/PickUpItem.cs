using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item item;
    public int count = 1;
    
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _pickUpDistance = 1.5f;
    [SerializeField] private float _timeToLeave = 10f;

    private Transform player;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
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
        _timeToLeave -= Time.deltaTime;
        if (_timeToLeave < 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void MoveToPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > _pickUpDistance)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
        
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
