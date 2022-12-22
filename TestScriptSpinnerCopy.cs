using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptSpinnerCopy : ScriptableObj
{
   // THIS IS A TEST TO MODIFY
    float speed = 0.1f;
    private void Update()
    {
        transform.localEulerAngles += new Vector3(0, speed, 0);
    }
}
