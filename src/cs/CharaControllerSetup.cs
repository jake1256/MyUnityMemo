using UnityEngine;
using System.Collections;

/**
 * 指定したキャラクターをキーで操作する
 */
public class CharaControllerSetup : MonoBehaviour {

	float forwardSpeed = 10f;
	float backwardSpeed = 3f;
	float rotateSpeed = 5f;
	float gravity = 20f;

	CharacterController controller;
	Animator animator;
	Vector3 vector;

	Vector3 colliderCenter;
	float colliderRadius;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();

		colliderCenter = controller.center;
		colliderRadius = controller.radius;
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");

		animator.SetBool("isAttack" , false);

		if(controller.isGrounded){
			vector = new Vector3(0 , 0 , v);
			animator.SetFloat("speed" , v);
			vector = transform.TransformDirection(vector);

			if(v > 0){
				vector *= forwardSpeed;
			}else{
				vector *= backwardSpeed;
			}

			if(Input.GetKey(KeyCode.Space)){
				animator.SetBool("isAttack" , true);
			}

		}

		vector.y -= gravity * Time.deltaTime;
		controller.Move(vector * Time.deltaTime);
		transform.Rotate(0 , h * rotateSpeed , 0);

		AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
		if(info.nameHash == Animator.StringToHash("Base Layer.Attack")){
			Vector3 newCenter = colliderCenter;
			newCenter.z += 1.0f;
			controller.center = newCenter;
		}else{
			controller.center = colliderCenter;
		}
	}
}
