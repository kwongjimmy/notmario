using UnityEngine;

public class boulder : MonoBehaviour {
    private bool ground = false;
    private bool fall = false;

    // Use this for initialization
    void Start () {
    }

	// Update is called once per frame
	void Update () {
        if (fall)
        {
            if (ground)
            {
                transform.position += Vector3.left * Time.deltaTime * 15f;
                transform.Rotate(0, 0, Time.deltaTime * 85f, Space.Self);
            }
            else
            {
                transform.position += Vector3.down * Time.deltaTime * 9f;
            }
        }
    }

    public void setFall(bool fall) {
        this.fall = fall;
    }

    bool IsGrounded() {
        float distToGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground" && IsGrounded())
            ground = true;
        else if (other.tag == "bounds") DestroyObject(this.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground" && !IsGrounded())
            ground = false;
    }

}
