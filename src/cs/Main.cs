using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject lance;

	private Vector3 touchPos; // fixPoint
	private bool isTouch;
	
	private float power = 6000;
	// Use this for initialization
	void Start () {
		lance.rigidbody.centerOfMass = new Vector3 (0, 1, 0);
		lance.rigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D col2d = Physics2D.OverlapPoint(tapPoint);
			if(col2d){
				GameObject obj = col2d.transform.gameObject;
				if(obj.name.Equals("PowerBar")){
					
				}
			}
		}

	}

	private bool updateLance(){
		if (Input.GetMouseButtonDown (0)) {
			touchPos = Input.mousePosition;
			lance.rigidbody.isKinematic = true;
			isTouch = true;
		}
		
		if (isTouch) {
			Vector3 nowPos = Input.mousePosition;
			int move = 0;
			if(touchPos.x < nowPos.x){
				move = 1;
			}
			else if(touchPos.x > nowPos.x){
				move = 2;
			}
			if(touchPos.y < nowPos.y){
				move = 2;
			}
			else if(touchPos.y > nowPos.y){
				move = 1;
			}
			
			Vector3 rotate = lance.transform.eulerAngles;
			if(move == 1){
				rotate.z = rotate.z - 1;
			}
			else if(move == 2){
				rotate.z = rotate.z + 1;
			}
			lance.transform.eulerAngles = rotate;
			
			
			touchPos = nowPos;
		}
		
		if (Input.GetMouseButtonUp (0)) {
			isTouch = false;
		}
	}

	public void fire(){
		lance.rigidbody.isKinematic = false;

		Vector3 pointPos = GameObject.FindGameObjectsWithTag ("Point") [0].transform.position;
		Vector3 pos = lance.transform.position;

		Vector3 resultPos = Vector3.Normalize (pointPos - pos);


		lance.rigidbody.AddForce (resultPos * power);
	}
}
