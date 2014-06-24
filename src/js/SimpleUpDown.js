#pragma strict

/**
 * 指定したオブジェクトが上下に移動する
 */
private var base : Vector3;
public var moveHeight : float = 2;
public var moveSpeed : float = 1;

function Start () {
	base = transform.position;
}

function Update () {
	transform.position.y = base.y + Mathf.Sin( Time.time * moveSpeed ) * moveHeight;
}
