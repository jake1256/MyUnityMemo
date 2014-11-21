using UnityEngine;
using System.Collections;

public class DeleteManager : MonoBehaviour {
	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void deleteCheckAll(){
		ArrayList pieceList = gameManager.PieceList;
		foreach (GameObject obj in pieceList) {
			Piece p = obj.GetComponent<Piece>();
			if(p.IsDel != true){
				// delete check
				checkPiece(pieceList , p);
			}
		}
	}

	private void checkPiece(ArrayList pieceList , Piece origin){
		int i 		= origin.ArrIdxI;
		int j 		= origin.ArrIdxJ;

		// right 3 , under 3 wo toru
		Piece pRight1 = gameManager.findPieceObject (i + 1, j);
		Piece pRight2 = gameManager.findPieceObject (i + 2, j);
		Piece pUnder1 = gameManager.findPieceObject (i , j + 1);
		Piece pUnder2 = gameManager.findPieceObject (i , j + 2);

		if (pRight1 != null && pRight2 != null) {
			checkImgIdx(origin , pRight1 , pRight2);
		}

		if (pUnder1 != null && pUnder2 != null) {
			checkImgIdx(origin , pUnder1 , pUnder2);
		}
	}

	private void checkImgIdx(Piece origin , Piece p1 , Piece p2){
		int imgIdx = origin.ImgIdx;
		int imgIdx1 = p1.ImgIdx;
		int imgIdx2 = p2.ImgIdx;
		if(imgIdx == imgIdx1 && imgIdx == imgIdx2){
			// delete!!
			origin.IsDel = true;
			p1.IsDel = true;
			p2.IsDel = true;
		}
	}
}
