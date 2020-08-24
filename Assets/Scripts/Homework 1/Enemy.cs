using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private GameObject impactParticles;
    private GameObject impact;
    [SerializeField]
    private AudioClip impactSound;

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player p = collision.collider.GetComponent<Player>();
        if(p != null)
        {
            PlayerCollide(p);
            ImpactFeedback(collision);
        }
    }

    protected virtual void PlayerCollide(Player p)
    {
        p.AdjustHealth(-damage);
    }

    private void ImpactFeedback(Collision c)
    {
        if (impact != null) Destroy(impact);
        if (impactParticles != null)
        {
            GameObject impact = Instantiate(impactParticles, c.GetContact(0).point, Quaternion.identity);
        }

        if (impactSound != null)
        {
            AudioHelper.PlayClip2D(impactSound, 0.3f);
        }
    }

    protected virtual void Move()
    {

    }
}
