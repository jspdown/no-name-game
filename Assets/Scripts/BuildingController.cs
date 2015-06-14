using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingController : MonoBehaviour {

	public int minParts;
	public int maxParts;
	public GameObject[] buildingParts;
	public float scale;
	
	private float height;
	private GameObject[] parts;
	private GameObject roof;
	private GameObject[] sides;
	private	int nbrSides;
	private int countPart;

	
	void Start () {
		int nbrParts = Random.Range(this.minParts, this.maxParts);

		this.height = 0.0f;
		this.parts = new GameObject[nbrParts];
		this.sides = new GameObject[nbrParts * 2];
		this.nbrSides = 0;

		this.selectRandomParts (nbrParts);
		this.probablyCall(0.8f, () => this.createRoof());

		foreach (GameObject floor in this.parts) {
			this.probablyCall(1f, () => this.createSide(floor));
		}
	}
	
	void Update () {
	
	}

	public void hidePart() {
		this.countPart--;
		if (this.countPart <= 0) {
			this.GetComponentInParent<CityController>().removeBuilding(this.gameObject);
			Destroy (this.gameObject);
		}
	}

	private int[] getBuildingPartsByTag(string tag) {
		int nbr = 0;

		for (int i = 0; i < this.buildingParts.Length; i++) {
			if (this.buildingParts[i].tag == tag) {
				nbr++;
			}
		}

		int[] indexes = new int[nbr];

		for (int i = 0, j = 0; i < this.buildingParts.Length; i++) {
			if (this.buildingParts[i].tag == tag) {
				indexes[j++] = i;
			}
		}
		return indexes;
	}


	private void selectRandomParts(int nbrParts) {
		int 	randomIdx;
		int[] 	baseParts;
		Vector3 position;


		baseParts = this.getBuildingPartsByTag ("building-part-base");
		this.height = 0.0f;
		for (int i = 0; i < nbrParts; i++) {
			randomIdx = baseParts[Random.Range(0, baseParts.Length)];
			position = new Vector3(
				this.buildingParts[randomIdx].transform.position.x + this.transform.position.x, 
				this.buildingParts[randomIdx].transform.position.y + this.transform.position.y + this.height, 
				0
			);

			this.parts[i] = GameObject.Instantiate(this.buildingParts[randomIdx], position, Quaternion.identity) as GameObject;
			this.countPart++;
			this.parts[i].transform.parent = this.transform;

			this.parts[i].transform.localScale = new Vector3(
				this.parts[i].transform.localScale.x * (Random.Range(0, 2) == 0 ? -1 : 1) * this.scale,
				this.parts[i].transform.localScale.y * this.scale,
				this.parts[i].transform.localScale.z * this.scale
			);

			this.height += this.parts[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y * this.parts[i].transform.localScale.y - 0.05f;
		}
	}

	private void createRoof() {
		int[] 	roofParts;
		int 	part;
		Vector3 position;

		roofParts = this.getBuildingPartsByTag ("building-part-roof");
		part = Random.Range (0, roofParts.Length);

		position = new Vector3 (
			this.buildingParts[roofParts[part]].transform.position.x + this.transform.position.x,
			this.buildingParts[roofParts[part]].transform.position.y + this.transform.position.y + this.height,
			0
		);

		this.roof = GameObject.Instantiate (this.buildingParts [roofParts [part]], position, Quaternion.identity) as GameObject;
		this.countPart++;
		this.roof.transform.parent = this.transform;

		this.roof.transform.localScale = new Vector3(
			this.roof.transform.localScale.x * this.scale * (Random.Range(0, 2) == 0 ? -1 : 1),
			this.roof.transform.localScale.y * this.scale,
			this.roof.transform.localScale.z * this.scale
		);

		this.height += this.roof.GetComponent<SpriteRenderer>().sprite.bounds.size.y * this.roof.transform.localScale.y - 0.05f;
	}

	private void createSide(GameObject floor) {
		int[] 		sideParts;
		int 		part;

		sideParts = this.getBuildingPartsByTag ("building-part-side");
		part = Random.Range (0, sideParts.Length);

		if (floor.GetComponent<BuildingPartController> ().sideLeft && !floor.GetComponent<BuildingPartController> ().sideRight) {
			this.createSideLeft (floor, sideParts [part]);
		} else if (!floor.GetComponent<BuildingPartController> ().sideLeft && floor.GetComponent<BuildingPartController> ().sideRight) {
			this.createSideRight (floor, sideParts [part]);
		} else if (floor.GetComponent<BuildingPartController> ().sideLeft && floor.GetComponent<BuildingPartController> ().sideRight) {
			if (Random.Range (0, 2) == 0) {
				this.createSideLeft (floor, sideParts [part]);
			} else {
				this.createSideRight (floor, sideParts [part]);
			}
		}
	}

	private void createSideLeft(GameObject floor, int sideId) {
		float 	sideWidth; 
		float 	floorWidth;
		Vector3 translation;
		Vector3 floorPosition;
		Vector3 localScale;

		sideWidth = this.buildingParts [sideId].GetComponent<SpriteRenderer> ().sprite.bounds.size.x * (this.buildingParts [sideId].transform.localScale.x * this.scale);
		floorWidth = floor.GetComponent<SpriteRenderer> ().sprite.bounds.size.x * 
			((floor.transform.localScale.x * this.scale) < 0.0f ? -(floor.transform.localScale.x * this.scale) : (floor.transform.localScale.x * this.scale));

		floorPosition = floor.transform.position;
		translation = new Vector3 (
			floorPosition.x - (floorWidth / 2 + sideWidth / 2) - this.buildingParts[sideId].transform.position.x,
			floorPosition.y,
			0
		);

		this.sides [this.nbrSides] = GameObject.Instantiate (this.buildingParts [sideId], translation, Quaternion.identity) as GameObject;
		this.countPart++;
		localScale = this.sides [this.nbrSides].transform.localScale;
		localScale.x *= -this.scale;
		localScale.y *= this.scale;
		this.sides [this.nbrSides].transform.localScale = localScale;
		this.sides[this.nbrSides].transform.parent = this.transform;

		this.nbrSides++;
	}

	private void createSideRight(GameObject floor, int sideId) {
		float 	sideWidth; 
		float 	floorWidth;
		Vector3 translation;
		Vector3 floorPosition;
		Vector3 localScale;

		sideWidth = this.buildingParts [sideId].GetComponent<SpriteRenderer> ().sprite.bounds.size.x * (this.buildingParts [sideId].transform.localScale.x * this.scale);
		floorWidth = floor.GetComponent<SpriteRenderer> ().sprite.bounds.size.x * 
			((floor.transform.localScale.x * this.scale < 0.0f ? -(floor.transform.localScale.x * this.scale) : (floor.transform.localScale.x * this.scale)));

		floorPosition = floor.transform.position;
		translation = new Vector3 (
			floorPosition.x + (floorWidth / 2 + sideWidth / 2) + this.buildingParts[sideId].transform.position.x,
			floorPosition.y + this.buildingParts[sideId].transform.position.y,
			0
		);
		this.sides [this.nbrSides] = GameObject.Instantiate (this.buildingParts [sideId], translation, Quaternion.identity) as GameObject;
		this.countPart++;
		localScale = this.sides [this.nbrSides].transform.localScale;
		localScale.x *= this.scale;
		localScale.y *= this.scale;
		this.sides [this.nbrSides].transform.localScale = localScale;
		this.sides[this.nbrSides].transform.parent = this.transform;

		this.nbrSides++;
	}


	private void probablyCall(float prob, System.Action func) {
		if (Random.value < prob) {
			func();
		}
	}

}






