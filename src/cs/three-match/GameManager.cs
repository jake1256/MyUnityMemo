using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private ArrayList pieceList;
	private DeleteManager delManager;
	private CreateManager createManager;
	public void init(ArrayList pieceList){
		this.pieceList = pieceList;
		delManager = GameObject.Find ("DeleteManager").GetComponent<DeleteManager> ();
		createManager = GameObject.Find ("CreateManager").GetComponent<CreateManager> ();
	}

	public void move(GameObject obj , Flick flick){
		Debug.Log ("GameManager origin name == " + obj.name + " flick == " + flick);

		GameObject impactObj = findImpactObject (obj, flick);
		if (impactObj != null) {
			PieceEvent origin = obj.GetComponent<PieceEvent> ();
			PieceEvent impact = impactObj.GetComponent<PieceEvent>();
			switch (flick) {
				case Flick.Left:
					origin.moveLeft ();
					impact.moveRight();
					break;
				case Flick.Right:
					origin.moveRight ();
					impact.moveLeft();
					break;
				case Flick.Up:
					origin.moveUp ();
					impact.moveDown();
					break;
				case Flick.Down:
					origin.moveDown ();
					impact.moveUp();
					break;
			}
			pieceReplace(obj , impactObj);
			delManager.deleteCheckAll();
			deletePieceList();
		}
	}

	private void deletePieceList(){
		int y = 5;
		ArrayList row = new ArrayList ();
		for (int i = 0; i < 5; i++) {
			row.Add (0);
		}

		// delete
		for (int i = 0 ; i < pieceList.Count ; i++) {
			GameObject obj = (GameObject)pieceList[i];
			Piece p = obj.GetComponent<Piece>();
			if(p.IsDel == true){
				row[p.ArrIdxI] = (int)row[p.ArrIdxI] + 1;
				PieceEvent pe = obj.GetComponent<PieceEvent>();
				pe.deletePiece();

				//pieceList.Remove(obj);
			}
		}

		// add create
		for (int i = 0; i < row.Count; i++) {
			y = 4;
			for(int j = 0 ; j < (int)row[i] ; j++){
				GameObject obj = createManager.createPiece(i , j , -2 + i , y);
				pieceList.Add(obj);
				y += 1;
			}
		}

		// fall
		foreach (GameObject obj in pieceList) {
			Piece p = obj.GetComponent<Piece> ();
			Debug.Log ("--- " + obj.name + " ---");
			Debug.Log("isDel == " + p.IsDel);
		}


	}

	private bool fallingDown(int i , int j){
		GameObject obj = findPieceGameObject (i , j - 1);
		if (obj != null) {
			Piece under = obj.GetComponent<Piece> ();
			if (under.IsDel) {
				PieceEvent pe = obj.GetComponent<PieceEvent> ();
				pe.moveDown ();
				return fallingDown (under.ArrIdxI, under.ArrIdxJ);
			}
		}
		return true;
	}

	private GameObject findImpactObject(GameObject obj , Flick flick){
		GameObject result = null;
		Piece p = obj.GetComponent<Piece> ();
		int i = p.ArrIdxI;
		int j = p.ArrIdxJ;

		Debug.Log ("origin i == " + i + " , j == " + j);

		switch (flick) {
		case Flick.Left:
			result = findPieceGameObject(i - 1 , j);
			break;
		case Flick.Right:
			result = findPieceGameObject(i + 1 , j);
			break;
		case Flick.Up:
			result = findPieceGameObject(i , j - 1);
			break;
		case Flick.Down:
			result = findPieceGameObject(i , j + 1);
			break;
		}

		return result;
	}

	private GameObject findPieceGameObject(int i , int j){
		foreach(GameObject obj in pieceList){
			Piece p = obj.GetComponent<Piece> ();
			if(i == p.ArrIdxI && j == p.ArrIdxJ){
				return obj;
			}
		}
		return null;
	}

	public Piece findPieceObject(int i , int j){
		foreach(GameObject obj in pieceList){
			Piece p = obj.GetComponent<Piece> ();
			if(i == p.ArrIdxI && j == p.ArrIdxJ){
				
				return p;
			}
		}
		return null;
	}

	private void pieceReplace(GameObject origin , GameObject impact){
		Piece originPiece = origin.GetComponent<Piece> ();
		Piece impactPiece = impact.GetComponent<Piece> ();

		int originI = originPiece.ArrIdxI;
		int originJ = originPiece.ArrIdxJ;

		originPiece.ArrIdxI = impactPiece.ArrIdxI;
		originPiece.ArrIdxJ = impactPiece.ArrIdxJ;

		impactPiece.ArrIdxI = originI;
		impactPiece.ArrIdxJ = originJ;

	}

	public ArrayList PieceList {
		get {
			return pieceList;
		}
	}
}
