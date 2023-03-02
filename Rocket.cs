using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : ScriptableObj
{
    public float forceToApply;
    public string RocketName = "Rocket";
    public int numInt;
    public bool isRocket = true;
    private ScriptableRigidBody MyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ScriptableObjDefaults>().Load();
        MyRigidBody = GetComponent<ScriptableRigidBody>();
        MyRigidBody.SetForce(Vector3.up * forceToApply);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<ScriptableRigidBody>().SetForce(Vector3.up * 10f);
        }
    }

}
