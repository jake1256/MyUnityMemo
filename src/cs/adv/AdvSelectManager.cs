using UnityEngine;
using System.Collections;

public class AdvSelectManager : MonoBehaviour {

	public AdvActionManager actionManager;

	public GameObject buttonGroup;

	public UILabel lblButton1;
	public UILabel lblButton2;
	public UILabel lblButton3;
	public UILabel lblButton4;

	private AdvSelect advSelect;

	void Start () {
		hide();
	}

	public void select(AdvData data){
		advSelect = (AdvSelect)data;

		lblButton1.text = advSelect.Select1;
		lblButton2.text = advSelect.Select2;
		lblButton3.text = advSelect.Select3;
		lblButton4.text = advSelect.Select4;

		show ();
	}

	public void buttonEvent(GameObject buttonObj){
		hide();

		string gotoStr = advSelect.SelectLabel;
		string btnName = buttonObj.name;
		switch(btnName){
		case "Button1":
			gotoStr = gotoStr + "1";
			break;
		case "Button2":
			gotoStr = gotoStr + "2";
			break;
		case "Button3":
			gotoStr = gotoStr + "3";
			break;
		case "Button4":
			gotoStr = gotoStr + "4";
			break;
		}
		actionManager.goToNext(gotoStr);
	}

	public void show(){
		buttonGroup.SetActive(true);
	}

	public void hide(){
		buttonGroup.SetActive(false);
	}
}
