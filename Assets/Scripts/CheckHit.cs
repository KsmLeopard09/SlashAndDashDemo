using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour, IHitReciever
{
    [SerializeField] private int health = 20;
    public void TakeHit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
