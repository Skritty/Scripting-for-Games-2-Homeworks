using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : CollectableBase
{
    [SerializeField]
    private int amount;

    protected override void Collect(Player p)
    {
        p.MaxHealth += amount;
        p.AdjustHealth(amount);
    }
}
