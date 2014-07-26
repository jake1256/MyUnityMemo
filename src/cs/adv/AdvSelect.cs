using UnityEngine;
using System.Collections;

public class AdvSelect : AdvData {
	private string select1;
	private string select2;
	private string select3;
	private string select4;

	public string Select1{
		get{ return this.select1; }
		set{ this.select1 = value; }
	}

	public string Select2{
		get{ return this.select2; }
		set{ this.select2 = value; }
	}

	public string Select3{
		get{ return this.select3; }
		set{ this.select3 = value; }
	}

	public string Select4{
		get{ return this.select4; }
		set{ this.select4 = value; }
	}

	public override void parse(string[] parseStr){
		base.parse(parseStr);
		this.select1 = parseStr[3];
		this.select2 = parseStr[4];
		this.select3 = parseStr[5];
		this.select4 = parseStr[6];

		Debug.Log("adv select parse : " + this.select1);
	}
}
