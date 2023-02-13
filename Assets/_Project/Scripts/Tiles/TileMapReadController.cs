using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TileMapReadController : MonoBehaviour
{
    public CropsManager cropsManager;
    
    [SerializeField] private Tilemap tilemap;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {
        Vector3 worldPosition;
        
        if (mousePosition)
        {
            worldPosition = _camera.ScreenToWorldPoint(position);
        }
        else
        {
            worldPosition = position;
        }
        
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return cellPosition;
    }
    
    public TileBase GetTileBase(Vector3Int gridPosition)
    {
        TileBase tile = tilemap.GetTile(gridPosition);
        
        return tile;
    }
}
