using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ToolAction/GatherResourceNode")]
public class GatherResourceNode : ToolAction
{
    [SerializeField] private float sizeOfInteractableArea = 1f;
    [SerializeField] private List<ResourceNodeType> canHitNodesOfType;
    
    public override bool OnApply(Vector2 worldPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);

        foreach (Collider2D collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            
            if (hit != null)
            {
                if (!hit.CanBeHit(canHitNodesOfType)) return false;
                
                hit.Hit();
                return true;
            }
        }
        
        return false;
    }
}

public enum ResourceNodeType
{
    Undefined,
    Tree,
    Ore,
}
