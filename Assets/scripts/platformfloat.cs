using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class platformfloat : MonoBehaviour
{

    // Use this for initialization
    public float fallSpeed;
    private bool fall;
    void Start()
    {
        fall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fall)
            transform.Translate(Vector3.up * fallSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        print("Triggered: " + other.tag);
        if (other.tag == "Player")
            fall = true;
        if (other.tag == "bounds")
            DestroyObject(this.gameObject);
    }
}
