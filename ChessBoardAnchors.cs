using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardAnchors : ScriptableObj
{
    public int step;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChessPiece")
        {
            float x = Mathf.RoundToInt(other.transform.localPosition.x / step) * step;
	    // There should be 2 dimensions in which chess is played. Y is not the one.
	    // Also, apply the changes to the piece
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ChessPiece")
        {
            Debug.Log("Exited " + other.name);
        }
    }
}