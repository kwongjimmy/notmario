using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {
    private Vector2 velocity;

    //public float smoothTimeY;
    //public float smoothTimeX;

    //public GameObject player;
    public Transform player;
    public Vector3 offset; 
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = new Vector3(player.position.x + 5, 0, player.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        //float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        //float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        //transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        transform.position = new Vector3(player.position.x + 2.5f, player.position.y + 3, -60);
        //transform.position = new Vector3(player.position.x+2.5f, 2.5f, -60);

    }
}
