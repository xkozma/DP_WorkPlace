using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFromCsharp : ScriptableObj
{
   // THIS IS A TEST FROM CSHARP
    float speed = 0.1f;
    private void Update()
    {
        transform.localEulerAngles += new Vector3(0, speed, 0);
    }
}
