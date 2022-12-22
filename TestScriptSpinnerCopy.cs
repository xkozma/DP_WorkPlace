using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : ScriptableObj
{
    float speed = 0.1f;
    private void Update()
    {
        transform.localEulerAngles += new Vector3(0, speed, 0);
    }
}
