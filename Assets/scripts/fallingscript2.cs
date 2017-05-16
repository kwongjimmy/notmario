using UnityEngine;
using UnityEngine.SceneManagement;

public class fallingscript2 : MonoBehaviour
{

    // Use this for initialization
    float fallSpeed;
    float distance;
    bool fall;
    void Start()
    {
        fallSpeed = 12.0f;
        fall = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = (GameObject.Find("player").transform.position.x) - transform.position.x;
        //print(distance);
        if (Mathf.Abs(distance) < 1.75f)
        {
            fall = true;
        }
        if (fall) transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            SceneManager.LoadScene("123");
        }
    }

}
