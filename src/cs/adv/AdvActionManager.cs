using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdvActionManager : MonoBehaviour {

	public AdvDataManager dataManager;
	public AdvViewManager viewManager;
	public AdvSelectManager selectManager;

	private List<AdvData> nowAdvList;
	private bool isInit;
	private int index;
	// Use this for initialization
	void Start () {
		index = 0;
		isInit = false;

	}

	public void goToNext(string val){
		nowAdvList = dataManager.getAdvList(val);
		index = 0;
		next();
	}

	public void next(){
		AdvData data = nowAdvList[index];
		switch(data.AdvType){
			case AdvType.None:
				// view ni watasu
				viewManager.view(data);
				break;
			case AdvType.Select:
				// select ni watasu
				selectManager.select(data);
				break;
			case AdvType.GoTo:
				string gotoStr = data.SelectLabel;
				goToNext(gotoStr);
				return;
		}
		index++;
	}

	void Update () {
		if(!isInit){
			if(dataManager.isLoadFinish()){
				goToNext("main1");
				isInit = true;
			}
		}
	}
}
