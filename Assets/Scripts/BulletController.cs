using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	public float lifeTime;

	private bool collide;
	private float dateOfBirth;

	void Start () {	
		this.collide = false;
		this.dateOfBirth = Time.time;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag.Contains ("enemy")) {
			Debug.Log ("Piou piou! piooouu!");
		}
		
		if (collision.gameObject.tag != "own-bullet") {
			this.GetComponent<Animator> ().SetTrigger ("Collide");
			this.collide = true;
		}
	}

	void Update () {
		if (Time.time >= this.dateOfBirth + this.lifeTime) {
			destroy();
		} else if (!this.collide) {
			this.transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
	}

	public void destroy() {
		GameObject bulletPool = GameObject.Find ("BulletPool");
		bulletPool.GetComponent<BulletPoolController> ().removeBullet (this.gameObject);	
		Destroy (this.gameObject);
	}
}
