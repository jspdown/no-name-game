using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}


	public void restart() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
