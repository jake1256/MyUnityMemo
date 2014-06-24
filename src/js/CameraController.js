#pragma strict

/**
 * カメラがキャラクターを追尾
 */
public var target : Transform;
public var distance : float = 4.0;
public var height : float = 2.0;

function Start () {

}

function Update () {
    transform.position = target.position + ( -Vector3.forward*distance ) +
        ( Vector3.up*height );
    transform.LookAt( target );
}
