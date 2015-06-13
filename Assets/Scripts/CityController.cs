using UnityEngine;
using System.Collections;

public class CityController : MonoBehaviour {

	public float citySize;
	public GameObject building;	
	public float minPos;
	public float maxPos;

	void Start () {
		float position = 0.0f;
		bool done = false;
		int i = 0;

		while (!done) {
			position += Random.Range(minPos, maxPos);
			i++;
			GameObject go = GameObject.Instantiate(
				this.building,
				new Vector3(this.transform.position.x + position, this.transform.position.y, this.transform.position.z),
				Quaternion.identity
			) as GameObject;

			go.transform.parent = this.transform;
			if (position > this.citySize) {
				done = true;
			}
		}

	}
	

	void Update () {
		
	}
}
