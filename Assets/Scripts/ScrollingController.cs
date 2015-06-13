using UnityEngine;
using System.Collections;

public class ScrollingController : MonoBehaviour {

	public float speed;

	private Vector3 speedVector;

	void Start () {
		this.speedVector = new Vector3 (-this.speed, 0, 0);
	}
	
	
	void Update () {
		this.transform.Translate (this.speedVector);
	}
}
