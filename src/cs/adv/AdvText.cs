using UnityEngine;
using System.Collections;

public class AdvText : AdvData{
	private string place;
	private string backGround;
	private string charaImg;
	private string message;

	public string Place{
		get{ return this.place; }
		set{ this.place = value; }
	}

	public string BackGround{
		get{ return this.backGround; }
		set{ this.backGround = value; }
	}

	public string CharaImg{
		get{ return this.charaImg; }
		set{ this.charaImg = value; }
	}

	public string Message{
		get{ return this.message; }
		set{ this.message = value; }
	}

	public override void parse(string[] parseStr){
		base.parse(parseStr);
		this.place = parseStr[3];
		this.backGround = parseStr[4];
		this.charaImg = parseStr[5];
		this.message = parseStr[6];

		Debug.Log("adv text parse : " + this.message);
	}

}
