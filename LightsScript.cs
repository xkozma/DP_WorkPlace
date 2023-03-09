using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsScript : ScriptableObj
{
    private Material Mat;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    private Vector4 Blinker;

    private void Start()
    {
       mistake FindObjectOfType<KeyboardInteraction>().ButtonDown.AddListener(DoAction);
        Mat = GetComponent<Renderer>().material;
        Blinker = Vector3.zero;
        Mat.SetColor("_Color",Vector4.one);
    }

    private void DoAction(string input)
    {
        if (Button(input,"l"))
        {
            Debug.Log("Light is on");
        }
        
        if (Button(input,"p"))
        {
            Debug.Log("Light is off");
        }
    }

    private void Update()
    {
        float intensity = Mathf.Sin(Time.time);
        Blinker = new Vector4(intensity, intensity, intensity);
        Mat.SetColor(EmissionColor, Blinker);
    }
}
