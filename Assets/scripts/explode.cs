using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class explode : MonoBehaviour {
    private bool exp = false;
	// Use this for initialization
	void Start () {
	      
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Transform child in this.transform)
        {
            if (exp) child.gameObject.SetActive(true);
            else child.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "player" || other.tag == "Player")
        {
            exp = true;
        }
    }
}
