using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private float slowSpeed = 12f;
    public float speed = 12f;
    public float fastSpeed = 20f;
    public float turnSmoothTime = 0.1f;

    public GameObject freeLookCamera;

    float turnSmoothVelocity;

    public Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 2f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight = 3f;

    public int maxJumps = 1;
    private int jumps = 1;

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            freeLookCamera.GetComponent<CinemachineFreeLook>().enabled = false;
            return;
        }

        freeLookCamera.GetComponent<CinemachineFreeLook>().enabled = true;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        if(isGrounded)
        {
            jumps = maxJumps;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && (isGrounded || jumps == 1)){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumps = 0;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if(Input.GetButtonDown("Sprint")){
            speed = fastSpeed;
        }

        if(Input.GetButtonUp("Sprint")){
            speed = slowSpeed;
        }
    }
}