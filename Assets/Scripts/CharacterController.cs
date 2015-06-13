using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float speed;

	void Start () {

	}
	
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			this.move(this.speed);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			this.move(-this.speed);
		}

		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log("SPACE");
		}
	}

	public void move(float speed) {
		this.transform.Translate (new Vector3 (0, speed, 0));
	}


}
