using UnityEngine;
using System.Collections;

public class TouchFocusController : MonoBehaviour {

	public GameObject controlCamera;
	public GameObject target;
	private Camera mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = controlCamera.GetComponent ("Camera") as Camera;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 vec = Input.mousePosition;

			Debug.Log ("mouse position x == " + vec.x);
			Debug.Log ("mouse position y == " + vec.y);
			Debug.Log ("mouse position z == " + vec.z);



			setFocus(vec);
		}
	}

	private void setFocus(Vector3 vec){
		vec.z = 10f;
		vec = mainCamera.ScreenToWorldPoint (vec);
		controlCamera.transform.LookAt (vec);
		target.transform.LookAt (vec);
	}
}
