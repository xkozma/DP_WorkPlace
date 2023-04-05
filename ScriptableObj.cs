using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScriptableObjDefaults))]

public class ScriptableObj : MonoBehaviour
{
    protected ButtonClicked VRInput;
    private void Start()
    {
        //Debug.Log("I compiled!");
        
    }

    protected bool Button(string button, string desiredButton)
    {
        return button.ToLower() == desiredButton.ToLower();
    }

    IEnumerator waitForLoad()
    {
        yield return new WaitForSeconds(1);
    }
    
}
