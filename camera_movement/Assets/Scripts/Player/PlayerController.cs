using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.EditorTools;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float playerSpeed = 6.0f;
    public float jumpHeight = 3f;
    public float gravityValue = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    private Vector3 distance = Vector3.zero;
    private Vector3 velocity;

    private KeyManager _k;
    private PlayerAnimations _animations;

    void Start()
	{
        _k = GameObject.FindObjectOfType<KeyManager>();
        _animations = GameObject.FindObjectOfType<PlayerAnimations>();
    }

    void Update()
    {
        Movement();
        Animations();
    }

    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDirectionForward = transform.forward * z;
        Vector3 moveDirectionSide = transform.right * x;
        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;

        if (direction.magnitude >= 0.1f)
		{
            //float TargetAngle = Mathf.Atan2(direction.x, 0f, direction.z) * Mathf.Rad2Deg;

            if (Input.GetKey(_k.sprint.ToString()) && Input.GetKey(_k.forward.ToString()) && (!Input.GetKey(_k.left.ToString()) && !Input.GetKey(_k.right.ToString())) && _animations.isWalking() == false)
            {
                distance = direction * playerSpeed * 2f * Time.deltaTime;
            } else if (_animations.isWalking() == true) {
                distance = direction * playerSpeed * 0.5f * Time.deltaTime;
            } else if (_animations.isWalking() == false && Input.GetKey(_k.backward.ToString())) {
                distance = direction * playerSpeed * 0.75f * Time.deltaTime;
            } else {
                distance = direction * playerSpeed * Time.deltaTime;
            }
            controller.Move(distance);
        }

        if (Input.GetKey(_k.jump.ToString()) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    void Animations()
	{
        //Movement w,s,a,d
        if (Input.GetKey(_k.forward.ToString())) _animations.isForward(true);
        else _animations.isForward(false);
        if (Input.GetKey(_k.backward.ToString())) _animations.isBackward(true);
        else _animations.isBackward(false);
        if (Input.GetKey(_k.left.ToString())) _animations.isLeft(true);
        else _animations.isLeft(false);
        if (Input.GetKey(_k.right.ToString())) _animations.isRight(true);
        else _animations.isRight(false);

        //Movement sprint, walk
        if (Input.GetKey(_k.sprint.ToString())) _animations.isSprint(true);
        else _animations.isSprint(false);
        if (Input.GetKeyDown(_k.walk.ToString()) && _animations.isWalking() == false) _animations.isWalk(true);
        else if (Input.GetKeyDown(_k.walk.ToString()) && _animations.isWalking() == true) _animations.isWalk(false);
    }

}
