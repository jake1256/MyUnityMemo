using UnityEngine;
using System.Collections;

public enum AdvType{
	None,
	Select,
	GoTo,
};
public class AdvData {


	private string label;
	private AdvType advType;
	private string selectLabel;

	public string Label{
		get{ return this.label; }
		set{ this.label = value; }
	}

	public AdvType AdvType{
		get{ return this.advType; }
		set{ this.advType = value; }
	}

	public string SelectLabel{
		get{ return this.selectLabel; }
		set{ this.selectLabel = value; }
	}

	public virtual void parse(string[] parseStr){


		this.label = parseStr[0];
		//this.advType = advTypeOf(parseStr[1]);
		this.selectLabel = parseStr[2];

		Debug.Log("adv data parse : " + this.label);
	}

	public static AdvData create(string str){
		AdvData result = null;
		if(str.Equals("select")){
			result = new AdvSelect();
			result.AdvType = AdvType.Select;
		}
		else if(str.Equals("goto")){
			result = new AdvGoTo();
			result.AdvType = AdvType.GoTo;
		}
		else{
			result = new AdvText();
			result.AdvType = AdvType.None;
		}
		return result;
	}
}
