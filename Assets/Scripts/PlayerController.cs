using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    IInput input;
    PlayerMovement movement;
    PlayerCombat combat;
    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null )
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        input = GetComponent<IInput>();
        movement = GetComponent<PlayerMovement>();
        combat = GetComponent<PlayerCombat>();
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
