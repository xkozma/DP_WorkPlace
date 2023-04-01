using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardAnchors : ScriptableObj
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChessPiece")
        {
            float x = Mathf.RoundToInt(other.transform.localPosition.x / 60) * 60;
            float z = Mathf.RoundToInt(other.transform.localPosition.z / 60) * 60;
            other.transform.localPosition = new Vector3(x,
                0,
                z);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ChessPiece")
        {
            //Debug.Log("Exited " + other.name);
        }
    }
}
