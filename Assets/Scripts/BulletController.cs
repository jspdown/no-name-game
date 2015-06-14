using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	public float lifeTime;

	private float dateOfBirth;

	void Start () {	
		this.dateOfBirth = Time.time;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag.Contains ("enemy")) {
			Debug.Log ("Piou piou! piooouu!");
		}
		this.destroy ();
	}

	void Update () {
		if (Time.time >= this.dateOfBirth + this.lifeTime) {
			this.destroy();
		} else {
			this.transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
	}

	private void destroy() {
		GameObject bulletPool = GameObject.Find ("BulletPool");
		bulletPool.GetComponent<BulletPoolController> ().removeBullet (this.gameObject);	
		Destroy (this.gameObject);
	}
}
