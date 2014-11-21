using UnityEngine;
using System.Collections;

public class ScriptCameraController : MonoBehaviour {

	// 動かしたいカメラオブジェクト
	public GameObject controlCamera;

	// 注視したいオブジェクト
	public GameObject target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// ここら辺はまぁテキトー
		if (Input.GetKey ("left")) {
			move (-0.1f , 0 , 0);
		} else if (Input.GetKey ("right")) {
			move(0.1f , 0 , 0);
		} else if (Input.GetKey ("up")) {
			move(0.0f , 0 , 0.1f);
		} else if (Input.GetKey ("down")) {
			move(0.0f , 0 , -0.1f);
		}

		// UpdateごとにLookAtを呼ばないと注視してくれない
		if (Input.GetButtonDown ("Fire1")) {
			start();
		}
	}

	private void start(){
		Vector3 startPosition = new Vector3 (0, 10, 0);
		controlCamera.transform.position = startPosition;
		controlCamera.transform.LookAt (getTargetPos());

		iTween.MoveTo (controlCamera, iTween.Hash (
					"position" , new Vector3(0 , 2 , -1),
					"time" , 2.0f,
					"oncomplete" , "move1",
					"oncompletetarget" , this.gameObject
				));
	}

	void move1(){
		Debug.Log ("move1");



		iTween.LookTo (controlCamera , iTween.Hash(
			"looktarget" , target.transform.forward,
			"time" , 2.0f,
			"oncomplete" , "move2",
			"oncompletetarget" , this.gameObject
			));
	}

	private void move2(){
		Debug.Log ("move2");
	}

	private void move(float valX , float valY , float valZ){
		float x = controlCamera.transform.localPosition.x;
		float y = controlCamera.transform.localPosition.y;
		float z = controlCamera.transform.localPosition.z;

		controlCamera.transform.localPosition = new Vector3 (x + valX ,  y + valY , z + valZ);
	}

	private Vector3 getTargetPos(){
		Vector3 pos = target.transform.position;
		pos.y = pos.y += 1.0f;
		return pos;
	}
}
