using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public AdvActionManager advActionManager;
	public AdvSelectManager advSelectManager;

	private bool isButtonPush;
	// Use this for initialization
	void Start () {
		isButtonPush = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isButtonPush){
			if(Input.GetMouseButtonUp(0)){
				advActionManager.next();
			}
		}else{
			isButtonPush = false;
		}
	}

	public void onButtonClick(GameObject buttonObj){
		advSelectManager.buttonEvent(buttonObj);
		isButtonPush = true;
	}
}
