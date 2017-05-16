using UnityEngine;

public class fallingscript : MonoBehaviour
{

    // Use this for initialization
    public float fallSpeed;
    float distancex;
    float distancey;
    bool fall;
    void Start()
    {
        fallSpeed = 22.0f;
        fall = false;
    }

    // Update is called once per frame
    void Update()
    {
        distancex = (GameObject.Find("player").transform.position.x) - transform.position.x;
        //distancey = (GameObject.Find("player").transform.position.y) - transform.position.y;
        //print(distance);
        if (Mathf.Abs(distancex) < 1.75f)
        {
            fall = true;
        }
        if (fall) transform.Translate(Vector3.up * fallSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bounds") Destroy(this.gameObject);
    }

}
