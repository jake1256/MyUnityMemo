using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CutSceneManager : MonoBehaviour {

	private bool isRunning;
	
	private float angle;

	private CutSceneData currentData;
	private Vector3 targetPositionFixed; // fixec

	public List<CutSceneData> dataList;

	//--------------------------------------------------
	// public method

	public void start(string name){
		currentData = findCutSceneData (name);
		if (currentData != null) 
		{
			if(currentData.target != null){
				targetPositionFixed = currentData.target.transform.position;
			}
			isRunning 		= true;
			angle 			= 0.0f;

			switch(currentData.type){
				case CutSceneData.CutSceneType.MOVE:
					StartCoroutine("startMoveCutScene");
					break;
				case CutSceneData.CutSceneType.ROTATE:
					StartCoroutine("startRotateCutScene");
					break;
			}
		}
	}

	public bool IsRunning(){
		return isRunning;
	}

	//--------------------------------------------------
	// private method

	// find cut scene data
	private CutSceneData findCutSceneData(string name){
		foreach (CutSceneData data in dataList) {
			if(data != null && data.name != null){
				if(name.Equals(data.name)){
					return data;
				}
			}
		}
		return null;
	}

	// move
	private IEnumerator startMoveCutScene(){
		// set start position
		this.gameObject.transform.position = currentData.startPosition;
		this.gameObject.transform.localRotation = Quaternion.Euler (currentData.startRotation);

		// move
		iTween.MoveTo(this.gameObject , 
		              iTween.Hash(
							"x" , currentData.endPosition.x , 
							"y" , currentData.endPosition.y , 
							"z" , currentData.endPosition.z , 
							"time" , currentData.time , 
							"oncomplete" , "finishCutScene" , 
							"oncompletetarget" , this.gameObject , 
							"easetype" , iTween.EaseType.linear
							)
		              );
		iTween.RotateTo(this.gameObject ,
		                iTween.Hash(
							"x" , currentData.endRotation.x , 
							"y" , currentData.endRotation.y , 
							"z" , currentData.endRotation.z , 
							"time" , currentData.time , 
							"easetype" , iTween.EaseType.linear
							)
		                );
		yield return null;
	}

	// rotate
	private IEnumerator startRotateCutScene(){

		angle = currentData.startRadius;


		yield return null;
	}

	// finish
	private IEnumerator finishCutScene(){

		Debug.Log ("finish cut scene");
		isRunning = false;
		currentData = null;
		angle = 0.0f;
		yield return null;
	}

	private void execLookAt(){
		if (currentData != null && currentData.target != null) {
			this.gameObject.transform.LookAt (targetPositionFixed);
		}
	}

	private void execRotate(){
		Vector3 targetPos = targetPositionFixed;

		this.gameObject.transform.position = new Vector3(
			targetPos.x + Mathf.Cos(angle) * currentData.distance , 
			targetPos.y , 
			targetPos.z + Mathf.Sin(angle) * currentData.distance
			);

		Debug.Log ("angle == " + angle);

		if (currentData.startRadius < currentData.endRadius) {
			if(angle < currentData.endRadius){
				angle += 0.01f;
			}else{
				StartCoroutine("finishCutScene");
			}
		} else {
			if(angle > currentData.endRadius){
				angle -= 0.01f;
			}else{
				StartCoroutine("finishCutScene");
			}
		}
	}

	// target look at
	void Update(){
		if (isRunning) {
			// rotate
			if (currentData != null) {
				// look at
				execLookAt();

				switch(currentData.type){
					// rotate
					case CutSceneData.CutSceneType.ROTATE:
						execRotate();
						break;
				}

			}
		}
	}
}
