using UnityEngine;
public class BoulderTrigger : MonoBehaviour {
    public GameObject go;
    // Use this for initialization
    void Start () {
        //go = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //GameObject go = GameObject.Find("Boulder");
            if (go != null) {
                boulder b = (boulder)go.GetComponent(typeof(boulder));
                b.setFall(true);
            }
        }
    }
}
