using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueController : ScriptableObj
{
    public float Torque;
    public float Strength;
    public bool IsOn;
    private int index;

    private void Spin()
    {
        Debug.Log("Im spinning");
    }
}
