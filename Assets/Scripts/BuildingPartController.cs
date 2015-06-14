using UnityEngine;
using System.Collections;

public class BuildingPartController : MonoBehaviour {

	public bool sideLeft;
	public bool sideRight;

	private bool seen;
	private SpriteRenderer parentRenderer;

	void Start () {
		this.seen = false;
		this.parentRenderer = this.GetComponent<SpriteRenderer> ();

	}
	
	void Update () {

		if (!this.seen && this.parentRenderer.isVisible) {
			this.seen = true;
		}
		if (this.seen && !this.parentRenderer.isVisible) {
			this.GetComponentInParent<BuildingController> ().hidePart ();
			Destroy (this.gameObject);
		}
	}
}
