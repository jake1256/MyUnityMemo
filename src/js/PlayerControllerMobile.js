#pragma strict

public var speed : float = 3;
public var jumpPower : float = 24;
public var pushPower : float = 10;
 
private var direction : Vector3 = Vector3.zero;
private var playerController:CharacterController;
private var animator : Animator;
private var leftJoystick : Joystick;
private var abutton : Joystick;
 
function Start() {
    playerController = GetComponent(CharacterController);
    animator = GetComponent(Animator);
    leftJoystick = GameObject.Find("LeftTouchPad").GetComponent(Joystick);
    abutton = GameObject.Find("AButton").GetComponent(Joystick);
}
 
function Update()  {    
 
    if (playerController.isGrounded) {  
        animator.SetBool("Jump" , false);
        var inputX : float = leftJoystick.position.x;
        var inputY : float = leftJoystick.position.y;
        var inputDirection : Vector3 = Vector3( inputX, 0, inputY );
        direction = Vector3.zero;
        
        if ( inputDirection.magnitude > 0.1 ) {
            transform.LookAt( transform.position + inputDirection );
            direction += transform.forward * speed;
            animator.SetFloat("Speed" , direction.magnitude);
        }else{
            animator.SetFloat("Speed" , 0);
        }
        if (abutton.tapCount) {
               direction.y += jumpPower;
               animator.SetBool("Jump" , true);
        }
    }
    
    direction.y += Physics.gravity.y* Time.deltaTime;

    playerController.Move(direction * Time.deltaTime);
}

function OnControllerColliderHit(hit : ControllerColliderHit){
    if(hit.gameObject.tag == "PushBlock"){
        hit.collider.attachedRigidbody.AddForce( transform.forward * pushPower );
    }
}
