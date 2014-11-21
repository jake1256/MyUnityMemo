using UnityEngine;
using System.Collections;

public enum Flick{
	Left = 1,
	Right = 2,
	Up = 3,
	Down = 4,
};


public class InputManager : MonoBehaviour {

	private Vector2 tapDown;
	private Vector2 tapUp;
	private GameObject hitGameObj;
	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

		// tap down point
		Vector2 tap = findTapDownPoint ();
		if (tap != Vector2.zero) {
			tapDown = tap;
			Collider2D col = Physics2D.OverlapPoint(tapDown);
			if(col){
				RaycastHit2D hitObj = Physics2D.Raycast(tapDown , -Vector2.up);
				if(hitObj){
					hitGameObj = hitObj.collider.gameObject;
					Debug.Log("hit game obj name == " + hitGameObj.name);
				}
			}
		}

		// tap up point
		tapUp = findTapUpPoint ();
		if (tapUp != Vector2.zero && tapDown != Vector2.zero && hitGameObj != null) {
			float flickX = tapUp.x - tapDown.x;
			float flickY = tapUp.y - tapDown.y;
			// x
			if(Mathf.Abs(flickX) > Mathf.Abs(flickY)){
				if(flickX < 0){
					// left
					gameManager.move(hitGameObj , Flick.Left);
				}else{
					// right
					gameManager.move(hitGameObj , Flick.Right);
				}
			}else{
				if(flickY < 0){
					// up
					gameManager.move(hitGameObj , Flick.Up);
				}else{
					// down
					gameManager.move(hitGameObj , Flick.Down);
				}
			}

			tapUp = Vector2.zero;
			tapDown = Vector2.zero;
			hitGameObj = null;
		}
	}

	private Vector2 findTapDownPoint(){
		// for PC
		if (Input.GetMouseButtonDown (0)) {
			Vector2 tapPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			return tapPos;
		}
		return Vector2.zero;
	}

	private Vector2 findTapUpPoint(){
		if (Input.GetMouseButtonUp (0)) {
			Vector2 tapPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			return tapPos;
		}
		return Vector2.zero;
	}
}
