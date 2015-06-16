using UnityEngine;
using System.Collections;

public class DestroyExplosion : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Destroy (animator.gameObject);
	}
}
