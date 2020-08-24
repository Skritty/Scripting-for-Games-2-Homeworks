using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectableBase
{
    [SerializeField]
    private int amount;

    protected override void Collect(Player p)
    {
        BallMotor m = p.motor;
        if(m != null)
        {
            m.MaxSpeed =  m.MaxSpeed + amount;
        }
    }

    protected override void Movement()
    {
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
