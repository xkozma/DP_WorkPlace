using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : ScriptableObj
{
    private LightsScript LightsScript;
    void Start()
    {
        FindObjectOfType<KeyboardInteraction>().ButtonDown.AddListener(DoAction);
        LightsScript = GetComponent<LightsScript>();
    }
    
    private void DoAction(string input)
    {
        if (Button(input,"o"))
        {
            Debug.Log("Light is off");
            LightsScript.isOn = false;
            LightsScript.Mat.SetColor("_Color",Vector4.zero);
        }

 if (Button(input,"l"))
        {
            Debug.Log("Light is on");
            LightsScript.isOn =true;
            LightsScript.Mat.SetColor("_Color",Vector4.one);
        }
    }

}
