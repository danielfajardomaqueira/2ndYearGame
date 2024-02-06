using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables

    public CharacterController controller;

    public float speed = 5;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private Vector3 playerGravity;
    public float gravityValue = -9.81f;

    public Transform cam;

    public ParticleSystem walkParticles;

    [SerializeField]private bool isMoving = false;

    //Animations
    public Animator animator;

    public string variableMovement;
    public string variableIsGround;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {

            // Movimiento del jugador para que siga de frente
            // adonde apunta la camara.
           
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            

            // Detecta cuando el jugador se mueve 
            // para generar o pausar particulas

            if (!isMoving)
            {
                walkParticles.Play();
                isMoving = true;
            }

        }
        else
        {
            if (isMoving)
            {
                walkParticles.Stop();
                isMoving = false;
            }
        }

        
        //Estas lineas hacen que el personaje tenga gravedad.
        
        playerGravity.y += gravityValue * Time.deltaTime;
        controller.Move(playerGravity * Time.deltaTime);


        //activan las animaciones
        animator.SetBool(variableIsGround, controller.isGrounded);
        animator.SetFloat(variableMovement, (Mathf.Abs(vertical) + Mathf.Abs(horizontal)));

    }

    
}
