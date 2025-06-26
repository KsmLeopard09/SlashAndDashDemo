using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHitReciever hitReciever = collision.gameObject.GetComponent<IHitReciever>();
        if(hitReciever != null)
        {
            hitReciever.TakeHit(10);
        }
    }
}
