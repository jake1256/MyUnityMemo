using UnityEngine;
using System.Collections;

public class AdvViewManager : MonoBehaviour {

	public SpriteRenderer bg;
	public SpriteRenderer chara;
	public UILabel labelMiniWindow;
	public TextWriter labelWindowWriter;

	public void view(AdvData data){
		AdvText txt = (AdvText)data;

		Debug.Log (txt.Label + ":" + txt.AdvType + ":" + txt.Message);

		if(isNotNull(txt.Place)){
			labelMiniWindow.text = txt.Place;
		}

		if(isNotNull(txt.BackGround)){
			Sprite[] textures = Resources.LoadAll<Sprite>("bg");
			Sprite bgSprite = System.Array.Find<Sprite>(textures
			                                            ,(sprite) => sprite.name.Equals(txt.BackGround));
			if(bgSprite != null){
				bg.sprite = bgSprite;
			}
		}

		if(isNotNull(txt.CharaImg)){
			var charaSprite = Resources.Load<Sprite>("chara/" + txt.CharaImg);
			if(charaSprite != null){
				chara.sprite = charaSprite;
			}
		}
		labelWindowWriter.start(txt.Message);
	}

	private bool isNotNull(string str){
		if(str != null && !"".Equals(str)){
			return true;
		}
		return false;
	}
}
