using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public TrailRenderer Particles,Particles1;
    public PauseMenu PauseMenu;

    public float speed = 13,gravity = -19.62f,jumpHeight = 3, Sprint,Walk, P_rate;
    Vector3 velocity;
    bool isGrounded,isRunning;
    

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject Cube;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    public static int Doublejump = 0;
    public GameObject Jump_particles;
    GameObject spawn;
    public Animator animator, moving;
    public CraftMenu craftmenu;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Sprint = speed * 2;
        Walk = speed;
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        craftmenu = GetComponent<CraftMenu>();
    }
    void Update()
    {
        if (animator.GetBool("IsOpen") == true || craftmenu.Open_inv == true || PauseMenu.isPaused == true)
        {

        } else {
            Move();
            Jump();
        }
        
        Gravity();
        
        Wall();
    }
    void Wall()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(Cube, spawn.transform.position, transform.rotation);
        }
    }
    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            Doublejump = 0;
            gravity = -19.62f;
            
        } else {
            gravity = gravity + (gravity * 0.003f);
        }
        if (isGrounded && velocity.y < 1)
        {
            velocity.y = -2f;
            moving.SetBool("IsJumping", false);
            moving.SetBool("IsDouble", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if(Doublejump == 0) // 1st jump
            { 
                moving.SetBool("IsJumping", true);
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                Doublejump++;
            }
            if (!isGrounded && Doublejump == 1) // 2nd jump
            {
                moving.SetBool("IsDouble", true);
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                Doublejump++;
            }
        }
        if (Doublejump == 2)
        {
            Jump_particles.SetActive(true);
        } else
        {
            Jump_particles.SetActive(false);
        }
    }
    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude >= 0.1f)
        {
            
            moving.SetBool("IsWalking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift)) // sprint
            {
            speed = Sprint;
            Particles.emitting = true;
            Particles1.emitting = true;
            isRunning = true;
            }
            moving.speed = 1f;
        } else {
            moving.SetBool("IsWalking", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = Walk;
            Particles.emitting = false;
            Particles1.emitting = false;
            isRunning = false;
        }
        if (moving.GetCurrentAnimatorStateInfo(0).IsTag("1") == true && isRunning == true)
        {
            moving.speed = 1.6f;
        } else {
            moving.speed = 1f;
        }
    }

}