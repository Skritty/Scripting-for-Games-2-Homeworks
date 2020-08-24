using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectableBase
{
    [SerializeField]
    private int amount;

    protected override void Collect(Player p)
    {
        p.Treasure += amount;
    }
}
