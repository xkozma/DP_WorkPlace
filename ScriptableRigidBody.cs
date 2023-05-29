using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ScriptableRigidBody : ScriptableObj
{
    private Rigidbody MyRigidBody;

    public float Mass = 0.0005f;
    public float Drag = 5f;
    
    private void Awake()
    {
        MyRigidBody = GetComponent<Rigidbody>();
        MyRigidBody.velocity = Vector3.zero;
        MyRigidBody.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if (MyRigidBody.mass != Mass)
        {
            MyRigidBody.mass = Mass;
        }
        // We need to set MyRigidBody drag as well as we did it with Mass
        // Pascal case, Camel case convetions are the same 
    
}

    public void SetMass(float val)
    {
        MyRigidBody.mass = val;
    }

    public void SetForce(float x, float y, float z)
    {
        Vector3 force = new Vector3(x, y, z);
        MyRigidBody.AddForce(force);
    }

    public void SetForce(Vector3 force)
    {
        MyRigidBody.AddForce(force);
    }

    public void SetGravity(bool value)
    {
        MyRigidBody.useGravity = value;
    }

    
}
