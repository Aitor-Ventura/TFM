using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialog : Interactable
{
    [SerializeField] private DialogContainer dialogContainer;
    
    public override void Interact(CharacterController2D character)
    {
        GameManager.Instance.dialogSystem.Initialize(dialogContainer);
    }
}
