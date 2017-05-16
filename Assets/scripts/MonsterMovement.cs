using UnityEngine;

public class MonsterMovement : MonoBehaviour {
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    public float speed;
    public float maxDist;
    private Vector3 startPos;
    private bool moveLeft;
    public float distancey;
    private bool fall;
    public float fallSpeed;


    // Use this for initialization
    void Start () {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        startPos = transform.position;
        fallSpeed = 22.0f;
        fall = false;
        moveLeft = true;
    }
	
	// Update is called once per frame
	void Update () {
        float distFromStart = Vector3.Distance(startPos, transform.position);
        //print(moveLeft + " distFromStart " + distFromStart);
        if (moveLeft && distFromStart >= maxDist) {
            moveLeft = false;
            SpriteRenderer.flipX = true;
            //transform.localScale = new Vector3(-0.25f, 0.25f, 1);
        } else if (!moveLeft && distFromStart <= 0.1) {
            moveLeft = true;
            SpriteRenderer.flipX = false;
            //transform.localScale = new Vector3(0.25f, 0.25f, 1);
        }
        if (moveLeft) { 
            transform.position += Vector3.left * Time.deltaTime * speed;
        } else {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }

        /*distancey = (GameObject.Find("player").transform.position.x) - transform.position.x;
        if (Mathf.Abs(distancey) < 0.5f)
        {
            fall = true;
        }*/
        if (fall) transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.Self);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("dead", true);
            fall = true;
        }
    }
}
