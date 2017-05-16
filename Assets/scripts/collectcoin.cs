using UnityEngine;
using System.Collections;

public class collectcoin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "player") {
			Destroy (this.gameObject);
		}
	}
}
