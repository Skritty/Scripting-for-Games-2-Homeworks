using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{
    [SerializeField]
    private float knockback = 1;

    protected override void PlayerCollide(Player p)
    {
        p.GetComponent<Rigidbody>().AddForce(knockback * (p.transform.position - transform.position).normalized, ForceMode.VelocityChange);
    }
}
