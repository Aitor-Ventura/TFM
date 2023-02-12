using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    [SerializeField] private Tilemap _targetTileMap;
    [SerializeField] private TileBase _tile;

    public Vector3Int markedCellPosition;
    
    private Vector3Int oldCellPosition;

    private void Update()
    {
        _targetTileMap.SetTile(oldCellPosition, null);
        _targetTileMap.SetTile(markedCellPosition, _tile);
        oldCellPosition = markedCellPosition;
    }
}
