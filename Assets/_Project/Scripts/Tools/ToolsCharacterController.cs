using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.Timeline;
using Vector2 = UnityEngine.Vector2;

public class ToolsCharacterController : MonoBehaviour
{
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;

    [SerializeField] private MarkerManager markerManager;
    [SerializeField] private TileMapReadController tileMapReadController;
    [SerializeField] private float maxDistance = 1.5f;

    [SerializeField] private ToolAction onTilePickuUp;

    private CharacterController2D _characterController;
    private Rigidbody2D _rigidbody;

    private Vector3Int _selectedTile;
    private bool _selectable;
    private Camera _camera;
    
    private ToolbarController _toolbarController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _toolbarController = GetComponent<ToolbarController>();
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
            if (UseToolWorld()) return;
            UseToolGrid();
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

    private bool UseToolWorld()
    {
        Vector2 position = _rigidbody.position + _characterController.lastMotionVector * offsetDistance;

        Item item = _toolbarController.GetItem;
        
        if (item == null || item.onAction == null) return false;

        bool complete = item.onAction.OnApply(position);
        
        if (complete)
        {
            if (item.onItemUsedAction == null) return false;
            item.onItemUsedAction.OnItemUsed(item, GameManager.Instance.inventoryContainer);
        }
        
        return complete;
    }

    private void UseToolGrid()
    {
        if (!_selectable) return;

        Item item = _toolbarController.GetItem;

        if (item == null)
        {
            PickUpTile();
            return;
        }
        if (item.onTileMapAction == null) return;

        bool complete = item.onTileMapAction.OnApplyToTileMap(_selectedTile, tileMapReadController, item);

        if (complete)
        {
            if (item.onItemUsedAction == null) return;
            item.onItemUsedAction.OnItemUsed(item, GameManager.Instance.inventoryContainer);
        }
    }

    private void PickUpTile()
    {
        if (onTilePickuUp == null) return;

        onTilePickuUp.OnApplyToTileMap(_selectedTile, tileMapReadController, null);
    }
}
