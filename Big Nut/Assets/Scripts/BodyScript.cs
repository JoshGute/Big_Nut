﻿using UnityEngine;
using System.Collections;

public class BodyScript : MonoBehaviour
{
    public Rigidbody rb;
    public float fLifetime;

    public bool bGrounded;
    public int iMaxJumps;
    public int iJumps;
    public float fMoveSpeed;
    public float fJumpSpeed;
    public float fDashTime;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        InvokeRepeating("updateLifeTime", 0, 1);
    }
	
    public void updateLifeTime()
    {
        print(fLifetime);
        if (fLifetime > 0)
        {
            --fLifetime;
        }
        else if (fLifetime <= 0)
        {
            Explode();
            CancelInvoke();
        }
    }

    public void Explode()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Rigidbody>().useGravity = true;
            child.GetComponent<Rigidbody>().isKinematic = false;
            child.GetComponent<Rigidbody>().AddExplosionForce(50.0f, child.transform.position, 30.0f);
            child.transform.rotation = Random.rotation;
        }
        rb.freezeRotation = false;
        transform.rotation = Random.rotation;
        transform.DetachChildren();
        rb.AddExplosionForce(300.0f, transform.position, 30.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            updateLifeTime();
        }

        if (collision.gameObject.tag == "Ground")
        {
            iJumps = iMaxJumps;
            bGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            bGrounded = false;
            
        }
    }
}
