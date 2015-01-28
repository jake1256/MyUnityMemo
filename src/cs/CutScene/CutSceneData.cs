using UnityEngine;
using System.Collections;


[System.Serializable]
public class CutSceneData {

	public enum CutSceneType{
		MOVE,
		ZOOM,
		ROTATE
	}

	// commmon
	public string name;
	public float time;
	public CutSceneType type;
	public GameObject target;

	[Header("Move Parameter")]
	// move
	public Vector3 startPosition;
	public Vector3 startRotation;
	public Vector3 endPosition;
	public Vector3 endRotation;

	[Header("Rotate Parameter")]
	// rotate
	public float distance;
	public float startRadius;
	public float endRadius;

	public void debug(){
		Debug.Log ("--- [name == " + name + "] ---");
		Debug.Log ("time == " + time);
		Debug.Log ("type == " + type);
		Debug.Log ("target == " + target);

		Debug.Log ("startPosition == " + startPosition);
		Debug.Log ("startRotation == " + startRotation);
		Debug.Log ("endPosition == " + endPosition);
		Debug.Log ("endRotation == " + endRotation);

		Debug.Log ("distance == " + distance);
		Debug.Log ("startRadius == " + startRadius);
		Debug.Log ("endRadius == " + endRadius);
	}

}
