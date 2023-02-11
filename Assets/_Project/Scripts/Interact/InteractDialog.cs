using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialog : Interactable
{
    public override void Interact(CharacterController2D character)
    {
        Debug.Log("Congrats! We are talking!");
    }
}
