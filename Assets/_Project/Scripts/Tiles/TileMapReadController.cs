using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TileMapReadController : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private List<TileData> tileData;

    private Dictionary<TileBase, TileData> _dataFromTiles;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileData)
        {
            foreach (var tile in tileData.tiles)
            {
                _dataFromTiles.Add(tile, tileData);
            }
        }
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

    public TileData GetTileData(TileBase tileBase)
    {
        return _dataFromTiles[tileBase];
    }
}
