using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Movement1 : MonoBehaviour 
{
    public CharacterController controller;
    public Transform cam;
    private ParticleSystem Particles;

    public float speed = 7,gravity = -9.81f,jumpHeight = 3, Sprint,Walk, P_rate;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    public static int Doublejump = 0;
    float timer = 0f;
    public GameObject test;
    GameObject spawn;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Sprint = speed * 2;
        Walk = speed;
        Particles = GetComponent<ParticleSystem>();
        spawn = GameObject.FindGameObjectWithTag("Spawn");
    }
    void Update()
    {
        Move();
        Jump();
        
        Gravity();
        
    }
    
    void Jump()
    {
        if (isGrounded)
        {
            Doublejump = 0;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (Doublejump < 1)
            {
                Doublejump++;
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
        }
        if (Doublejump == 1)
        {
            test.SetActive(true);
        } else
        {
            test.SetActive(false);
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
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        var em = Particles.emission;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = Sprint;
            em.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = Walk;
            em.enabled = false;
        }
    }

}