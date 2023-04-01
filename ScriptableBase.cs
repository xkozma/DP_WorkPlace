using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableBase : ScriptableObj
{
    void Start()
    {
        GetComponent<ScriptableObjDefaults>().Load();
    }
}
