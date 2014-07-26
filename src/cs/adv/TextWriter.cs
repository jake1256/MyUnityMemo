using UnityEngine;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

public class TextWriter : MonoBehaviour {

	private UILabel lbl;
	private string text;

	// Use this for initialization
	void Start () {
		lbl = GetComponent<UILabel>();
	}



	// Update is called once per frame
	void Update () {
	
	}

	public void start(string txt){
		StartCoroutine(textWriter(txt));
	}

	IEnumerator textWriter(string text){

		int len = 0;
		StringBuilder sb = new StringBuilder();
		lbl.text = sb.ToString();

		Regex r = new Regex(@"^\[[0-9A-F]{6}\]$");



		yield return null;
		
		while(len < text.Length){
			// Font Colorの評価
			string txt = text.Substring( len , 1 );
			if (txt == "["){
				if (len+3 < text.Length){
					txt = text.Substring( len , 3 );
					if (txt == "[-]"){
						sb.Append( txt );
						len += 3;
					} else if (len+8 < text.Length){
						txt = text.Substring( len , 8 );
						if (r.IsMatch(txt)){
							sb.Append( txt );
							len += 8;
						}   
					}
				}
				if (len >= text.Length) break;
			}
			sb.Append( text.Substring( len , 1 ) );
			lbl.text = sb.ToString();
			len++;
			//Debug.Log(len);
			yield return new WaitForSeconds(0.1f);
		}
		yield return null;
	}
}
