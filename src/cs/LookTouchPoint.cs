using UnityEngine;
using System.Collections;

/**
 * タッチした所に振り向く
 */
public class LookTouchPoint : MonoBehaviour {

	public GameObject chara;
	public Camera camera;

	private Vector3 vec;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0)){
			vec = Input.mousePosition;
			vec.z = 9.0f;

			vec = camera.ScreenToWorldPoint(vec);

			vec = vec * -1;

			vec.y = 0.0f;

			chara.animation.CrossFade("gun_burst");

			ShootRobo sr = chara.GetComponent("ShootRobo") as ShootRobo;
			sr.shot();
		}

		if(Input.GetMouseButtonUp(0)){
			chara.animation.CrossFade("walking");
		}

		Vector3 charap = chara.transform.position;


		chara.transform.rotation = Quaternion.Slerp(chara.transform.rotation, Quaternion.LookRotation(charap - vec), 0.07f);

	}

}
