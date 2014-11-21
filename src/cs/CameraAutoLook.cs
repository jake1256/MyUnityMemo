using UnityEngine;
using System.Collections;

public class CameraAutoLook : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (obj.transform);
	}
}
