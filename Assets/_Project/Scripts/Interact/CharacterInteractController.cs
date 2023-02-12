using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    [SerializeField] private float _interactDistance = 1f;
    [SerializeField] private float _sizeOfInteractableArea = 1.2f;
    [SerializeField] private HighlightController _highlightController;
    
    private CharacterController2D characterController;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        rigidbody = GetComponent<Rigidbody2D>();
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
        Vector2 position = rigidbody.position + characterController.lastMotionVector * _interactDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _sizeOfInteractableArea);

        foreach (var collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                _highlightController.Highlight(interactable.gameObject);
                return;
            }
        }
        
        _highlightController.Hide();
    }

    private void Interact()
    {
        Vector2 position = rigidbody.position + characterController.lastMotionVector * _interactDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _sizeOfInteractableArea);
        
        foreach (var collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(characterController);
                break;
            }
        }
    }
}
