using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	private CutSceneManager cutSceneManager;
	private int touchCount;

	// Use this for initialization
	void Start () {
		touchCount = 0;
		cutSceneManager = GameObject.Find ("Main Camera").GetComponent<CutSceneManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			testStart();
		}
	}

	private void testStart(){
		if (!cutSceneManager.IsRunning ()) {
			switch(touchCount % 3){
				case 0:
					cutSceneManager.start ("test1");
					break;
				case 1:
					cutSceneManager.start ("test2");
					break;
				case 2:
					cutSceneManager.start("test3");
					break;
			}
			touchCount++;
		}
			
	}

}
