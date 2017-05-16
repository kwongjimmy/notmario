using UnityEngine;

public class platformdrop : MonoBehaviour
{

    // Use this for initialization
    public float fallSpeed = 15.0f;
    public float delay;
    private bool fall = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fall)
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        print("Triggered: " + other.tag);
        if (other.tag == "Player")
            Invoke("setFall", delay); 
        else if (other.tag == "bounds")
            Destroy(this.gameObject);
    }
    void setFall()
    {
        fall = true;
    }

}
