using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Timeline;
using Vector2 = UnityEngine.Vector2;

public class ToolsCharacterController : MonoBehaviour
{
    [SerializeField] private float _offsetDistance = 1f;
    [SerializeField] private float _sizeOfInteractableArea = 1.2f;

    [SerializeField] private MarkerManager _markerManager;
    [SerializeField] private TileMapReadController _tileMapReadController;
    
    private CharacterController2D characterController;
    private Rigidbody2D rigidbody;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void Marker()
    {
        Vector3Int gridPosition = _tileMapReadController.GetGridPosition(Input.mousePosition, true);
        _markerManager.markedCellPosition = gridPosition;
    }

    private void UseTool()
    {
        Vector2 position = rigidbody.position + characterController.lastMotionVector * _offsetDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _sizeOfInteractableArea);

        foreach (Collider2D collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
