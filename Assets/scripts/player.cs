using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;

    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private AudioSource audio1;
    private AudioSource audioBGM;
    private bool playerAlive;


    private float counter = 0;
    private float counter2 = 0;
    void Start()
    {
        playerAlive = true;
        animator = GetComponent <Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<CharacterController>();
        audioBGM = GetComponent<AudioSource>();
        audio1 = gameObject.AddComponent<AudioSource>();
        speed = 10;
        jumpSpeed = 13;
        gravity = 25;
    }
    void Update()
    {
        if (playerAlive)
        {
            if (controller.isGrounded)
            {
                counter = 0;
                animator.SetBool("jumping", false);
                if (counter2 > 3) counter2 = 0;
                if (Input.GetAxis("Horizontal") != 0)
                {
                    if (Input.GetAxis("Horizontal") < 0) SpriteRenderer.flipX = true;
                    else SpriteRenderer.flipX = false;
                    animator.SetBool("idle", false);
                    animator.SetBool("running", true);
                }
                else
                {
                    animator.SetBool("running", false);
                    animator.SetBool("idle", true);
                }
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if ((Input.GetButton("Jump") || Input.GetKey("up") || Input.GetKey("w")) && counter2 < 1)
                {
                    audio1.PlayOneShot((AudioClip)Resources.Load("jump_01"));
                    animator.SetBool("idle", false);
                    animator.SetBool("running", false);
                    animator.SetBool("jumping", true);
                    moveDirection.y = jumpSpeed;

                }
                counter2++;
            }
            else
            {
                if ((Input.GetButton("Jump") || Input.GetKey("up") || Input.GetKey("w")) && counter < 25)
                {
                    counter++;
                    moveDirection.y += 0.15f;
                }
                if (Input.GetAxis("Horizontal") != 0)
                {
                    if (Input.GetAxis("Horizontal") < 0) SpriteRenderer.flipX = true;
                    else SpriteRenderer.flipX = false;
                }
                moveDirection.x = Input.GetAxis("Horizontal") * (speed * 0.85f);
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bounds" || other.tag == "obstacle")
        {
            playerAlive = false;
            audioBGM.volume = 0;
            controller.enabled = false;
            audio1.PlayOneShot((AudioClip)Resources.Load("smb_mariodie"));
            Invoke("restartLevel", 3.0f);
            
        }
        if(other.tag == "coin")
        {
            audio1.PlayOneShot((AudioClip)Resources.Load("smb_coin"));
            other.gameObject.SetActive(false);
        }
        if(other.tag == "enemy")
        {
            audio1.PlayOneShot((AudioClip)Resources.Load("smb_stomp"));
        }
        if(other.tag == "win")
        {
            playerAlive = false;
            audioBGM.volume = 0;
            controller.enabled = false;
            audio1.PlayOneShot((AudioClip)Resources.Load("victory"));
            Invoke("troll", 4.0f);

        }
    }
    void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void troll()
    {
        audio1.PlayOneShot((AudioClip)Resources.Load("smb_mariodie"));
        Invoke("loadMenu", 3.0f);
    }
    void loadMenu()
    {
        SceneManager.LoadScene("Title");
    }
}

