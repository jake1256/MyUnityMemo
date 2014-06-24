#pragma strict

/**
 * 色々書いてるけど、キーを押下するとコルーチン経由でイベントが進んでいく
 */
public var character : CharacterController;
public var animator : Animator;
public var mainCamera : Camera;
public var ballCamera : GameObject;
public var ball : GameObject;
private var direction : Vector3 = Vector3.zero;

function Start () {
	character = GetComponent(CharacterController);
	animator = GetComponent(Animator);
	mainCamera = Camera.main;
}

function Update () {
	animator.SetBool("Attack" , false);
	animator.SetBool("Win" , false);
	animator.SetBool("Lose" , false);
	if(Input.GetButton("Jump")){
		animator.SetBool("Attack" , true);

		StartCoroutine("cameraStart");
	}

	var inputX = Input.GetAxis("Horizontal");
	if(inputX > 0){
		animator.SetBool("Win" , true);
	}
	else
	if(inputX < 0){
		animator.SetBool("Lose" , true);
	}
}

function cameraStart(){
	yield WaitForSeconds(1.3);
	animator.speed = 0;
	mainCamera.SendMessage("HalfRotate");
}

function kickRestart(){
	animator.speed = 1;

	ballShoot();
}

function ballShoot(){
	var vec = Vector3(0 , 10 , 1000);
	ball.rigidbody.AddForce(vec);
	mainCamera.enabled = false;
	ballCamera.SetActive(true);
}
