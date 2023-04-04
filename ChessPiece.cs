using Enumerators;
using UnityEngine;

public class ChessPiece : ScriptableObj
{
    // One from: [Pawn,Rook,Queen,Bishop,King,Knight]
    public PieceType PieceType;
    // One from: [Black, White]
    public PieceColor PieceColor;
    // Start is called before the first frame update
    void Start()
    {
        if(PieceType == PieceType.King)
        {
            Debug.Log("I am " + gameObject.name);
            ResolveTheGame(PlayerPiece.White);
        }
    }

    void Update(){
        ResolveTheGame(PlayerPiece.White);
    }

    public void ResolveTheGame(PlayerPiece winner)
    {
        if (winner == PlayerPiece.White)
        {
            if (PieceType == PieceType.King && PieceColor == PieceColor.White)
            {
                transform.localPosition = new Vector3(240, 2, 240);
            }
            else if (PieceType == PieceType.King)
            {
                transform.localPosition = new Vector3(180, 2, 180);
            }
            else if (Vector3.Distance(transform.localPosition, new Vector3(240, 2, 240)) < 10 || Vector3.Distance(transform.localPosition, new Vector3(240, 2, 300)) < 10 )
            {
                transform.localPosition = new Vector3(500, 2, 500);
            }
        }
    }
}