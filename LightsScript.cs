using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsScript : ScriptableObj
{
    public Material Mat;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    private Vector4 Blinker;
    
    //Added
    public bool isOn;

    private void Start()
    {
        Mat = GetComponent<Renderer>().material;
        Blinker = Vector3.one;
        Mat.SetColor("_Color",Vector4.one);
        isOn = true;
    }
    

    private void Update()
    {
        float intensity = Mathf.Sin(Time.Time);
        Blinker = new Vector4(intensity, intensity, intensity);
        if(isOn)
            Mat.SetColor(EmissionColor, Blinker);
        else
            Mat.SetColor(EmissionColor, Vector4.zero);
    }
}
