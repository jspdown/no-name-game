using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPoolController : MonoBehaviour {

	public 	int 				poolSize;

	private List<GameObject>	pool;


	void Start () {
		this.pool = new List<GameObject>();
	}
	
	void Update () {
	}

	public void addBullet(GameObject prefab, Vector3 position, float speed) {
		GameObject bullet;

		if (this.pool.Count < this.poolSize) {
			bullet = GameObject.Instantiate (prefab, position + Vector3.right, Quaternion.identity) as GameObject;
			BulletController bc = bullet.AddComponent<BulletController> ();
			bc.speed = speed;
			bc.lifeTime = 10.0f;

			this.pool.Add (bullet);
		}
	}
	
	public void removeBullet(GameObject bullet) {
		this.pool.Remove (bullet);
	}
}
