using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using Vector2 = UnityEngine.Vector2;

public class ToolsCharacterController : MonoBehaviour
{
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;

    [SerializeField] private MarkerManager markerManager;
    [SerializeField] private TileMapReadController tileMapReadController;
    [SerializeField] private float maxDistance = 1.5f;
    
    private CharacterController2D _characterController;
    private Rigidbody2D _rigidbody;

    private Vector3Int _selectedTile;
    private bool _selectable;
    private Camera _camera;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void SelectTile()
    {
        _selectedTile = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    private void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;

        markerManager.Show(_selectable);
    }

    private void Marker()
    {
        markerManager.markedCellPosition = _selectedTile;
    }

    private void UseTool()
    {
        Vector2 position = _rigidbody.position + _characterController.lastMotionVector * offsetDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

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
