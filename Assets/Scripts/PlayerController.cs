using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    IInput input;
    PlayerMovement movement;
    PlayerCombat combat;

    private void OnEnable()
    {
        input = GetComponent<IInput>();
        movement = GetComponent<PlayerMovement>();
        input.OnMovementDirectionInput += movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
        input.OnAttackInput += combat.HandleAttack;
    }

    private void OnDisable()
    {
        input.OnMovementDirectionInput -= movement.HandleMovementDirection;
        input.OnMovementInput -= movement.HandleMovement;
        input.OnAttackInput -= combat.HandleAttack;
    }
}
