using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ScriptableRigidBody : ScriptableObj
{
    private Rigidbody MyRigidBody;
    private void Awake()
    {
        MyRigidBody = GetComponent<Rigidbody>();
        MyRigidBody.velocity = Vector3.zero;
        MyRigidBody.angularVelocity = Vector3.zero;
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
