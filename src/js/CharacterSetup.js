#pragma strict

/**
 * キャラクター選択されたらselectedCharacterに落ちる
 */
private var animator : Animator;

function Start () {
	animator = GetComponent(Animator);
}

function Update () {

}

function selectedCharacter (flg : boolean) {
	animator.SetBool("isAttackIdle" , flg);
}