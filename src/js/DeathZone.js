#pragma strict

/**
 * 指定した範囲に落ちた場合は死亡とみなす。（リトライなので、最初から）
 */
function Start () {

}

function Update () {

}

function OnTriggerEnter( col : Collider ) {
     if( col.tag == "Player" ) {
         Application.LoadLevel( Application.loadedLevel );
     }
}
