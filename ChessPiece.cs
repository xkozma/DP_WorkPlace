using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : ScriptableObj
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.rotation = new Quaternion(0,0,0,0); 
    }
}
