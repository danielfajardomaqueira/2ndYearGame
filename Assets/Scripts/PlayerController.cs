using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables
    [Header("Variables")]

    public CharacterController controller;

    public float speed = 5;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private Vector3 playerGravity;
    public float gravityValue = -9.81f;

    public Transform cam;

    private bool isMoving = false;

    //GetLogParticles
    [Header("Particles")]
    public ParticleSystem walkParticles;
    public Transform getLogParticles;

    //Animations
    [Header("Animations")]
    public Animator animator;

    public string variableMovement;
    public string variableIsGround;

    //Sounds
    [Header("Sounds")]
    public AudioSource playerSound;
    public AudioClip walkSFX;
    public AudioClip recolectableSFX;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {

            // Movement of the player so that he continues facing where the camera is pointing
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            controller.Move(moveDir.normalized * speed * Time.deltaTime);



            // Detects when the player moves to generate or pause walking particles
            if (!isMoving)
            {
                walkParticles.Play();
                isMoving = true;
                playerSound.Play();
            }

        }
        else
        {
            if (isMoving)
            {
                walkParticles.Stop();
                isMoving = false;
                playerSound.Stop();
            }
        }

        // These lines make the character have gravity
        playerGravity.y += gravityValue * Time.deltaTime;
        controller.Move(playerGravity * Time.deltaTime);

        // Set the animations
        animator.SetBool(variableIsGround, controller.isGrounded);
        animator.SetFloat(variableMovement, (Mathf.Abs(vertical) + Mathf.Abs(horizontal)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Recolectable")
        {
            Instantiate(getLogParticles, transform.position, Quaternion.identity);
            playerSound.PlayOneShot(recolectableSFX, 1.0f);
        }
    }
    
}
