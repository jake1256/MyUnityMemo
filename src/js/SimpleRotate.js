#pragma strict

/**
 * そのオブジェクトがクルクルと360度回ってる
 */

function Start () {

}

function Update () {
	transform.eulerAngles.y = Mathf.Repeat( Time.time , 1) * 360f;
}
