using UnityEngine;
using System.Collections;

public class Spiketrap2Trigger : MonoBehaviour {
    private bool collide;
    public float maxDistance;
	// Use this for initialization
	void Start () {
        collide = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (collide && this.transform.position.y < maxDistance)
        {
            this.transform.position += new Vector3(0, 0.15f, 0);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") collide = true;
    }
}
