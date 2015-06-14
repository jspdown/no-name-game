using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float 			speed;
	public GameObject 		machineGunPrefab;

	private GameObject 		machineGun;

	void Start () {
		this.machineGun = GameObject.Instantiate (this.machineGunPrefab, new Vector3(), Quaternion.identity) as GameObject;
		this.machineGun.transform.parent = this.transform;
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			this.move(Vector2.up);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			this.move(-Vector2.up);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.move(-Vector2.right);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.move(Vector2.right);
		}

		if (Input.GetKey (KeyCode.Space)) {
			this.machineGun.GetComponent<MachineGunController>().shoot(this.transform.position);
		}
	}

	void OnCollisionTrigger2D(Collision2D collision) {

	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag.Contains ("building-part")) {
			this.die ();
		}
	}

	public void move(Vector2 direction) {
		this.transform.Translate (Mathf.Cos(Time.deltaTime) * this.speed * direction * Time.deltaTime);
	}

	public void die() {
		Application.LoadLevel (Application.loadedLevel);
	}


}
