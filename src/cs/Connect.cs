using UnityEngine;
using System.Collections;
using MiniJSON;

/**
 * 通信はこんな感じ
 */
public class Connect : MonoBehaviour{

	private string URL = "";

	public void connect(){
		StartCoroutine(getConnect (URL));
	}

	private IEnumerator getConnect(string url){
		WWW www = new WWW(url);
		yield return www;
		if(www.error != null){
			Debug.Log("connect get error!!");
		}else{
			Debug.Log("success!! connect get");
			parseJSON(www.text);
		}
	}

	private IEnumerator postConnect(string url){
		WWWForm wwwForm = new WWWForm();
		wwwForm.AddField("param" , 1);
		WWW www = new WWW(url);

		yield return www;

		if(www.error != null){
			Debug.Log("connect get error!!");
		}else{
			Debug.Log("success!! connect post");

			parseJSON(www.text);
		}

	}

	private void parseJSON(string responseData){
		// webサーバからの内容を文字列変数に格納
		string json = responseData;
		// 以降JSONのパースは同じ
		IList familyList = (IList)Json.Deserialize(json);

		foreach(IDictionary person in familyList){
			string name = (string)person["name"];
			Debug.Log("name:"+name);

			long age = (long)person["age"];
			Debug.Log("age:"+age);

			IList hobbes = (IList)person["hobby"];
			foreach(string hobby in hobbes){
				Debug.Log("hobby:"+hobby);
			}
		}
	}
}
