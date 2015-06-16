using UnityEngine;
using System.Collections;

public class TowerReload : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Debug.Log ("Set Shoot false");
		animator.SetBool ("shoot", false);	

	}
}
