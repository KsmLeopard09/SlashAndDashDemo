using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttackState : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private BoxCollider2D weaponCollider;
    private bool colliderActive;
    // Start is called before the first frame update
    void Start()
    {
        colliderActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackHitState()
    {
        playerAttack.isAttacking = false;
    }
    public void Hit()
    {
        colliderActive = !colliderActive;
        weaponCollider.gameObject.SetActive(colliderActive);
    }
}
