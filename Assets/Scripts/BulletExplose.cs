using UnityEngine;
using System.Collections;

public class BulletExplose : StateMachineBehaviour {

	public GameObject explosion;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Transform bullet = animator.GetComponentInParent<Transform>();
		GameObject city = GameObject.Find("City") as GameObject;
		Quaternion rotation = new Quaternion (0, 0, Random.Range(0, 2f * Mathf.PI), 1);
		Vector3 position = new Vector3 (bullet.position.x, bullet.position.y, -2f);
		GameObject explosion = GameObject.Instantiate (this.explosion, position, rotation) as GameObject;

		explosion.transform.parent = city.transform;
		animator.ResetTrigger ("Collide");

		animator.GetComponentInParent<BulletController> ().destroy ();
	}
}
