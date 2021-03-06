﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CollectableBase : MonoBehaviour
{
    protected abstract void Collect(Player p);
    [SerializeField]
    private float movementSpeed = 1;
    protected float MovementSpeed { get => movementSpeed; }
    [SerializeField]
    private GameObject impactParticles;
    [SerializeField]
    private AudioClip impactSound;

    private GameObject impact;
    protected Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        Quaternion turnOffset = Quaternion.Euler(0, movementSpeed, 0);
        rb.MoveRotation(turnOffset * rb.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if (p != null)
        {
            Collect(p);
            Feedback();
            gameObject.SetActive(false);
        }
    }

    private void Feedback()
    {
        if (impact != null) Destroy(impact);
        if (impactParticles != null)
        {
            GameObject impact = Instantiate(impactParticles, transform.position, Quaternion.identity);
        }

        if (impactSound != null)
        {
            AudioHelper.PlayClip2D(impactSound, 0.3f);
        }
    }
}
