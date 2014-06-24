#pragma strict

/**
 * isHalfRotateがオンになるとカメラがキャラクターの方向を向きながら半回転する
 */
public var target : GameObject;
public var radius : float = 5;
public var distance : float = 5;
public var angle : float = 0;
public var speed : float = 1;
public var player : GameObject;
private var isHalfRotate : boolean = false;
private var pos2 : Vector3;
function Start () {
	pos2 = transform.position;
}

function Update () {
	if(isHalfRotate){
		if(angle > -5){
			var pos = target.transform.position;
			
			pos.y += 0.2;
			transform.LookAt(pos);

			transform.position = Vector3(pos.x + Mathf.Cos(angle) * radius , pos.y + distance , pos.z + Mathf.Sin(angle) * radius);
			angle -= speed;
		}else{
			isHalfRotate = false;
			player.SendMessage("kickRestart");
		}
		
	}
	
}

function HalfRotate(){
	isHalfRotate = true;
}
