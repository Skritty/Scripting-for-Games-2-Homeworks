using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : PowerUpBase
{
    [SerializeField]
    private Color colorChange;
    private Color oldColor;

    public override void PowerDown(Player p)
    {
        p.immune = false;
        p.GetComponent<Renderer>().material.color = oldColor;
    }

    protected override void PowerUp(Player p)
    {
        p.immune = true;
        oldColor = p.GetComponent<Renderer>().material.color;
        p.GetComponent<Renderer>().material.color = colorChange;
    }
}
