#pragma strict


/**
 * キャラクター選択はこんな感じ
 */

private var selectId : int;
public var characterList : GameObject[];
private var min : int;
private var max : int;

function Start () {
	selectId = characterList.Length / 2;
}

function Update () {
	if (Input.GetButtonDown("Horizontal"))
    {
	    if (Input.GetAxis("Horizontal") > 0)
	    {
	    	if(selectId < characterList.Length - 1){
				selectId++;
				selectCharacter();
			}
	    	
	    	Debug.Log("right");
	    }
	    else
	    {
	    	if(selectId > 0){
				selectId--;
				selectCharacter();
			}
	    	Debug.Log("left");
	    }
    }
}

function selectCharacter () {
	Debug.Log("selectId : " + selectId);
	for (var i = characterList.Length - 1; i >= 0; i--) {
		var chara : GameObject = characterList[i] as GameObject;
		if(i == selectId){
			chara.SendMessage("selectedCharacter" , true);
		}else{
			chara.SendMessage("selectedCharacter" , false);
		}
	};
	
}