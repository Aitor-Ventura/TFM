using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class CropsManager : TimeAgent
{
    [SerializeField] private TileBase plowed;
    [SerializeField] private TileBase seeded;
    [SerializeField] private Tilemap targetTileMap;
    [SerializeField] private GameObject cropsSpritePrefab;

    private Dictionary<Vector2Int, CropTile> _crops;

    private void Start()
    {
        _crops = new Dictionary<Vector2Int, CropTile>();
        onTimeTick += Tick;
        Init();
    }

    public void Tick()
    {
        foreach (CropTile cropTile in _crops.Values)
        {
            if (cropTile.crop == null) continue;
            
            cropTile.growTimer += 1;

            if (cropTile.growTimer >= cropTile.crop.growthStageTime[cropTile.growStage])
            {
                cropTile.renderer.gameObject.SetActive(true);
                cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage];
                
                cropTile.growStage += 1;
            }
            
            if (cropTile.growTimer >= cropTile.crop.timeToGrow)
            {
                cropTile.crop = null;
            }
        }
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

    public void Seed(Vector3Int position, Crop toSeed)
    {
        targetTileMap.SetTile(position, seeded);
        _crops[(Vector2Int) position].crop = toSeed;
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        CropTile cropTile = new CropTile();
        _crops.Add((Vector2Int) position, cropTile);

        GameObject go = Instantiate(cropsSpritePrefab);
        go.transform.position = targetTileMap.CellToWorld(position);
        go.transform.position -= Vector3.forward * 0.01f;
        go.SetActive(false);
        
        
        cropTile.renderer = go.GetComponent<SpriteRenderer>();
        
        targetTileMap.SetTile(position, plowed);
    }
}

public class CropTile
{
    public int growTimer;
    public int growStage;
    public Crop crop;
    public SpriteRenderer renderer;
}
