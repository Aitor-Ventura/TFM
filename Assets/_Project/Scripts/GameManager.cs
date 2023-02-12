using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemDragAndDropController itemDragAndDropController;
    
    private void Awake()
    {
        Instance = this;
    }
}
