﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Enemy
{
    protected override void PlayerCollide(Player p)
    {
        p.Die();
    }
}
