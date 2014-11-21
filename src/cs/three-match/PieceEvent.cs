using UnityEngine;
using System.Collections;

public class PieceEvent : MonoBehaviour {

	private const float DISTANCE = 1.0f;
	private const float TIME = 0.2f;

	public void moveLeft(){
		iTween.MoveBy (this.gameObject, iTween.Hash ("x", -DISTANCE, "time", TIME));
	}

	public void moveRight(){
		iTween.MoveBy (this.gameObject, iTween.Hash ("x", DISTANCE, "time", TIME));
	}

	public void moveUp(){
		iTween.MoveBy (this.gameObject, iTween.Hash ("y", -DISTANCE, "time", TIME));
	}

	public void moveDown(){
		iTween.MoveBy (this.gameObject, iTween.Hash ("y", DISTANCE, "time", TIME));
	}

	public void deletePiece(){
		iTween.ScaleTo (this.gameObject, iTween.Hash ("x", 0.1f, "y", 0.1f, "time", 0.5f , "oncomplete" , "death" , "oncompletetarget" , this.gameObject));
	}

	private void death(){
		//Debug.Log ("death");
		//Destroy (this.gameObject);
	}
}
