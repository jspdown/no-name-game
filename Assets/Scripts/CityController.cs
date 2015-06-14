using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityController : MonoBehaviour {

	public float citySize;
	public GameObject buildingPrefab;	
	public float minPos;
	public float maxPos;
	public int poolSize;

	private List<GameObject> pool;

	private float currentPosition;

	void Start () {
		this.pool = new List<GameObject>();
		this.currentPosition = 0.0f;
	}

	void Update () {
		while (this.pool.Count < this.poolSize) {
			this.createBuilding();
		}
	}

	public void removeBuilding(GameObject building) {
		this.pool.Remove (building);
	}

	public void createBuilding() {
		GameObject 	building;
		Vector3 	position;

		position = this.transform.position;
		this.currentPosition += Random.Range (this.minPos, this.maxPos);
		position.x += this.currentPosition;
		building = GameObject.Instantiate(this.buildingPrefab, position, Quaternion.identity) as GameObject;
		building.transform.parent = this.transform;

		this.pool.Add (building);
	}




	
	private void probablyCall(float prob, System.Action func) {
		if (Random.value < prob) {
			func();
		}
	}


}
