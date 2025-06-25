using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttackState : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackState()
    {
        playerAttack.isAttacking = false;
    }
}
