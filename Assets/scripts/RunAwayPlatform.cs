using UnityEngine;

public class RunAwayPlatform : MonoBehaviour {

	// Use this for initialization
	public float speed = 20.0f;
    private bool triggered = false;
    public Vector3 direction;

    void Start () {
	}

    public void setTriggered(bool triggered) {
        this.triggered = triggered;
    }

    // Update is called once per frame
    void Update () 
	{
		if (triggered)
            transform.Translate(direction * speed * Time.deltaTime, Space.Self);
	}
}
