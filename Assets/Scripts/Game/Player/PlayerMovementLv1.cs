using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovementLv1 : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Animator anim;
    private SpriteRenderer sprite;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);
        _rigidbody.velocity = _smoothedMovementInput * _speed;

        UpdateAnimation();
        
    }

    private void UpdateAnimation()
    {
        if (_movementInput == Vector2.zero)
        {
            anim.SetBool("Walking", false);
        }
        if (_movementInput != Vector2.zero)
        {
            //plip sprite
            if (_movementInput.x < 0)
            {
                sprite.flipX = true;
            }
            if (_movementInput.x >= 0)
            {
                sprite.flipX = false;
            }
            anim.SetBool("Walking", true);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
