using UnityEngine;

public class TriggerPlatform : MonoBehaviour {
    public GameObject go;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //GameObject go = GameObject.Find("Double Platform 41");
            RunAwayPlatform b = (RunAwayPlatform)go.GetComponent(typeof(RunAwayPlatform));
            b.setTriggered(true);
        }
    }
}
