using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdvDataManager : MonoBehaviour{

	private Hashtable advDataTable;

	private bool loadFinish;

	void Start () {
		loadFinish = false;
		this.advDataTable = new Hashtable();;
	}

	public void setAdvList(List<AdvData> advList){
		List<AdvData> tempList = null;
		string label = null;
		foreach(AdvData data in advList){
			if(data.Label != null && !data.Label.Equals("")){
				if(label != null){
					advDataTable.Add(label , tempList);
				}

				label = data.Label;
				tempList = new List<AdvData>();

			}

			tempList.Add(data);

		}

		if(label != null){
			advDataTable.Add(label , tempList);
		}

		loadFinish = true;
	}

	public List<AdvData> getAdvList(string key){
		return ((List<AdvData>)advDataTable[key]);
	}

	public bool isLoadFinish(){
		return loadFinish;
	}
}
