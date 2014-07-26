using UnityEngine;
using System.Collections;

public class TextSetManager : MonoBehaviour {

//	public SpriteRenderer bg;
//	public SpriteRenderer chara;
//	public UILabel labelMiniWindow;
//	public LoadTextManager loadTextManager;
//	public TextWriter labelWindowWriter;
//	private int index;
//
//
//	// Use this for initialization
//	void Start () {
//		index = 0;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//	}
//
//	public void next(){
//		AdvData data = loadTextManager.getAdvData(index);
//		if(data != null && data.AdvType == AdvType.None){
//			setText((AdvText)data);
//			index++;
//		}
//	}
//
//	public void setText(AdvText txt){
//		labelMiniWindow.text = txt.Place;
//		if(txt.BackGround != null && !"".Equals(txt.BackGround)){
//			Debug.Log ("change bg : " + txt.BackGround);
//			Sprite[] textures = Resources.LoadAll<Sprite>("bg");
//
//			Debug.Log(textures);
//			Sprite bgSprite = System.Array.Find<Sprite>(textures
//			                                         ,(sprite) => sprite.name.Equals(txt.BackGround));
//			Debug.Log(bgSprite);
//			if(bgSprite != null){
//				bg.sprite = bgSprite;
//			}
//		}
//		if(txt.CharaImg != null && !"".Equals(txt.CharaImg)){
//			Debug.Log ("change chara : " + txt.CharaImg);
//			var charaSprite = Resources.Load<Sprite>("chara/" + txt.CharaImg);
//			Debug.Log(charaSprite);
//
//			if(charaSprite != null){
//				chara.sprite = charaSprite;
//			}
//		}
//		labelWindowWriter.start(txt.Message);
//	}
}
