using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class CropsManager : MonoBehaviour
{
    [SerializeField] private TileBase plowed;
    [SerializeField] private TileBase seeded;
    [SerializeField] private Tilemap targetTileMap;

    private Dictionary<Vector2Int, Crop> _crops;

    private void Start()
    {
        _crops = new Dictionary<Vector2Int, Crop>();
    }

    public bool Check(Vector3Int position)
    {
        return _crops.ContainsKey((Vector2Int) position);
    }

    public void Plow(Vector3Int position)
    {
        if (_crops.ContainsKey((Vector2Int) position)) return;

        CreatePlowedTile(position);
    }

    public void Seed(Vector3Int position)
    {
        targetTileMap.SetTile(position, seeded);
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        Crop crop = new Crop();
        _crops.Add((Vector2Int) position, crop);
        
        targetTileMap.SetTile(position, plowed);
    }
}

public class Crop
{
    
}
