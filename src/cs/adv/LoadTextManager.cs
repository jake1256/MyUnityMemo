using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LoadTextManager : MonoBehaviour {

	public AdvDataManager advDataManager;

	private List<AdvData> advDataList;

	// Use this for initialization
	void Start () {
		advDataList = new List<AdvData>();
		StartCoroutine(Load());
	}

	IEnumerator Load(){
		var coroutine = loadTextFile("text_data.txt");
		yield return StartCoroutine(coroutine);
		ArrayList txtList = (ArrayList)coroutine.Current;
		create(txtList);
		
		yield return null;
	}

	public IEnumerator loadTextFile(string textFileName){
		TextReader txtReader;
		string txtBuffer = "";
		string path = "";
		ArrayList txtList = new ArrayList();
		#if UNITY_EDITOR
		path = Application.streamingAssetsPath + "/" + textFileName;
		FileStream file = new FileStream(path,FileMode.Open,FileAccess.Read);
		txtReader = new StreamReader(file);
		yield return new WaitForSeconds(0f);
		#elif UNITY_ANDROID
		path = "jar:file://" + Application.dataPath + "!/assets" + "/" + textFileName;
		WWW www = new WWW(path);
		yield return www;
		txtReader = new StringReader(www.text);
		#endif
		while((txtBuffer = txtReader.ReadLine()) != null){
			txtList.Add(txtBuffer);
		}

		yield return txtList;
	}

	void create(ArrayList txtList){
		AdvData data = null;
		foreach(string str in txtList){
			var split = str.Split(',');
			if(split.Length >= 7){
				data = AdvData.create(split[1]);

				Debug.Log(data);

				data.parse(split);

				advDataList.Add(data);
			}
		}

		advDataManager.setAdvList(advDataList);
	}

}
