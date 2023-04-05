using Enumerators;
using Events;
using UnityEngine;

public class ChessPiece : ScriptableObj
{
    private int step;

    // One from: [Pawn,Rook,Queen,Bishop,King,Knight]
    public PieceType PieceType;

    // One from: [Black, White]
    public PieceColor PieceColor;

    // Start is called before the first frame update
    void Start()
    {
        if (PieceType == PieceType.King)
        {
            //Debug.Log("I am " + gameObject.name);
        }

        ClockEvents.ClockTimeEndedEvent.AddListener(ResolveTheGame);
	step = FindObjectOfType<ChessBoardAnchors>().step;
    }


    public void ResolveTheGame(PlayerPiece winner)
    {
        if (winner == PlayerPiece.White)
        {
            if (PieceType == PieceType.King && PieceColor == PieceColor.White)
            {
                transform.localPosition = new Vector3(step * 4, 2, step * 4);
            }
            else if (PieceType == PieceType.King)
            {
                transform.localPosition = new Vector3(step * 3, 2, step * 3);
            }
            else if (Vector3.Distance(transform.localPosition, new Vector3(step * 4, 0, step * 4)) < 100 ||
                     Vector3.Distance(transform.localPosition, new Vector3(step * 3, 2, step * 3)) < 100)
            {
                transform.localPosition = new Vector3(500, 2, 500);
            }
        }
        else
        {
            if (PieceType == PieceType.King && PieceColor == PieceColor.Black)
            {
                transform.localPosition = new Vector3(step * 3, 2, step * 4);
            }
            else if (PieceType == PieceType.King)
            {
                transform.localPosition = new Vector3(step * 4, 2, step * 3);
            }
            else if (Vector3.Distance(transform.localPosition, new Vector3(step * 3, 2, step * 4)) < 100 ||
                     Vector3.Distance(transform.localPosition, new Vector3(step * 4, 2, step * 3)) < 100)
            {
                transform.localPosition = new Vector3(500, 2, 500);
            }
        }
    }
}