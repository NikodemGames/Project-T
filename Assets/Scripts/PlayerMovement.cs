using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    PlayerCombat pc;
    Animator animator;
    public float rotationSpeed, gravity = 20;
    Vector3 _movementVector = Vector3.zero;
    private float _desiredRotationAngle=0;

    private void Start()
    {
        pc = GetComponent<PlayerCombat>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();    
    }
    private void Update()
    {
        if (controller.isGrounded)
        {
            if (_movementVector.magnitude > 0)
            {
                var animationSpeedMultiplier = SetCorrectAnimation();
                RotatePlayer();
                _movementVector *= animationSpeedMultiplier;
            }
        }
        if(!animator.GetBool("IsAttacking"))
        {
            _movementVector.y -= gravity;
            controller.Move(_movementVector * Time.deltaTime);
        }

    }

    public void HandleMovementDirection(Vector3 direction)
    {
        _desiredRotationAngle = Vector3.Angle(transform.forward, direction);
        var crossProduct = Vector3.Cross(transform.forward, direction).y;
        if(crossProduct < 0)
        {
            _desiredRotationAngle *= -1;
        }
    }
    private void RotatePlayer()
    {
        if(_desiredRotationAngle>10 || _desiredRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * _desiredRotationAngle * rotationSpeed * Time.deltaTime);
        } 
    }
    public void HandleMovement(Vector2 input)
    {
        if (controller.isGrounded)
        {
            if (input.y > 0)
            {
                _movementVector = transform.forward * pc.stats.MoveSpeed;
            }
            else if (input.y < 0)
            {
                _movementVector = -transform.forward * pc.stats.MoveSpeed;
            }
            else
            {
                _movementVector = Vector3.zero;
                animator.SetFloat("move", 0);
            }
        }
    }

    private float SetCorrectAnimation()
    {
        float currentAnimationSpeed = animator.GetFloat("move");
        if (_desiredRotationAngle > 10 || _desiredRotationAngle < -10)
        {
            if (currentAnimationSpeed < 0.2)
            {
                currentAnimationSpeed += Time.deltaTime * 2;
                currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, 0, 0.2f);
            }
            animator.SetFloat("move", currentAnimationSpeed);
        }
        else
        {
            if(currentAnimationSpeed < 1)
            {
                currentAnimationSpeed += Time.deltaTime * 2;
            }
            else
            {
                currentAnimationSpeed = 1;
            }
            animator.SetFloat("move", currentAnimationSpeed);
        }
        return currentAnimationSpeed;
    }


}
