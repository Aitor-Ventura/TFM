using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterInteractController : MonoBehaviour
{
    [SerializeField] private float interactDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;
    [SerializeField] private HighlightController highlightController;
    
    private CharacterController2D _characterController;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Check();
        
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Check()
    {
        Vector2 position = _rigidbody.position + _characterController.lastMotionVector * interactDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (var collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                highlightController.Highlight(interactable.gameObject);
                return;
            }
        }
        
        highlightController.Hide();
    }

    private void Interact()
    {
        Vector2 position = _rigidbody.position + _characterController.lastMotionVector * interactDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        
        foreach (var collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(_characterController);
                break;
            }
        }
    }
}
