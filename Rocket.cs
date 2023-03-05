using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : ScriptableObj
{
    public float forceToApply = 69f;
    public string RocketName = "Rocket";
    public int numInt = 5;
    public bool isRocket = true;
    private ScriptableRigidBody MyRigidBody;
    public TorqueController tq;
    
    // Start is called before the first frame update
    void Start()
    {  FindObjectOfType<KeyboardInteraction>().ButtonDown.AddListener(DoAction);
        GetComponent<ScriptableObjDefaults>().Load();
        MyRigidBody = GetComponent<ScriptableRigidBody>();
        MyRigidBody.SetForce(Vector3.up * forceToApply);
    }

    private void DoAction(string input)
    {
        if (Button(input,"space"))
        {
            MyRigidBody.SetForce(Vector3.up * forceToApply); 
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<ScriptableRigidBody>().SetForce(Vector3.up * 10f);
        }
    }

}
