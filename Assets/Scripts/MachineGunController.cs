using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachineGunController : MonoBehaviour {

	public GameObject			bulletPrefab;

	public float				bulletSpeed;
	public float 				bulletFrequency;

	private GameObject			bulletPool;
	private float 				lastBulletTime;
	private float				bulletDeltaTime;

	
	void Start () {
		this.bulletPool = GameObject.Find ("BulletPool");

		this.lastBulletTime = Time.time;
		this.bulletDeltaTime = 1.0f / this.bulletFrequency;
	}
	
	
	void Update () {

	}

	public void shoot(Vector3 position) {
		if (Time.time >= this.lastBulletTime + this.bulletDeltaTime) {
			this.bulletPool.GetComponent<BulletPoolController>().addBullet(this.bulletPrefab, position, this.bulletSpeed);
			this.lastBulletTime = Time.time;
		}
	}
}
