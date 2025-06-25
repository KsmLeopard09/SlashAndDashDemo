using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private PlayerMove movement;
    [SerializeField] private float attackCooldown = 2.0f;
    [SerializeField] private float cooldownTimer;
    [SerializeField] private bool attacking;
    [SerializeField] private PlayerAnimationHandler animationHandler;

    [SerializeField] public bool isAttacking
    {
        get => attacking;
        set => attacking = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        cooldownTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleAttackInput();
        HandleCooldown();
    }
    private void HandleAttackInput()
    {
        if (input.AttackPressed && !attacking && cooldownTimer <= 0f)
        {
            StartAttack();
            Debug.Log("Attacking");
        }
    }
    void StartAttack()
    {
        attacking = true;
        cooldownTimer = attackCooldown;
        animationHandler.UpdateAttackAnimation();
    }
    void HandleCooldown()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (attacking && cooldownTimer <= 0f)
        {
            attacking = false;
        }
    }
}
