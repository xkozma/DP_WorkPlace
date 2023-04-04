using System.Collections;
using System.Collections.Generic;
using Enumerators;
using UnityEngine;

public class ChessPiece : ScriptableObj
{
    // One from: [Pawn,Rook,Queen,Bishop,King,Knight]
    public PieceType PieceType;
    // Start is called before the first frame update
    void Start()
    {
        if(PieceType == PieceType.King)
        {
            Debug.Log("I am " + gameObject.name);

            transform.localPosition = new Vector3(180,2,300);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
