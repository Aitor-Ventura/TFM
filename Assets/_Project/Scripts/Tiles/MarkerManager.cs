using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    public Vector3Int markedCellPosition;
    
    [SerializeField] private Tilemap targetTileMap;
    [SerializeField] private TileBase tile;

    private Vector3Int _oldCellPosition;
    private bool _show;

    private void Update()
    {
        if (!_show) return;
        
        targetTileMap.SetTile(_oldCellPosition, null);
        targetTileMap.SetTile(markedCellPosition, tile);
        _oldCellPosition = markedCellPosition;
    }

    public void Show(bool selectable)
    {
        _show = selectable;
        targetTileMap.gameObject.SetActive(_show);
    }
}
