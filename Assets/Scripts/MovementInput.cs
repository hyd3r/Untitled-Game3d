
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    public float velocity = 9f;
    public float jumpForce = 10f;
    public float gravity = 1f;
    public Transform groundCheck;
    public float groundDistance=0.4f;
    public LayerMask groundLayer;
    public bool isGrounded;
    [Space]

    private float InputX;
    private float InputZ;
    private Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;
	public Animator anim;
    private float Speed;
	public float allowPlayerRotation = 0.1f;
    private Camera cam;
    private CharacterController controller;
    [Space]
    public float smoothRotationTime = 0.2f;


    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;


    private Vector3 moveVector;
    public bool canMove;

	void Start () {
        anim = this.GetComponent<Animator> ();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();
    }
	
	void Update () {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        if (isGrounded && moveVector.y < 0)
        {
            moveVector.y = -1f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded && canMove)
        {
            moveVector.y = jumpForce;
            anim.SetTrigger("jump");
        }
        if (!isGrounded)
        {
            moveVector.y = moveVector.y + (Physics.gravity.y * gravity * Time.deltaTime);
        }
        controller.Move(moveVector * Time.deltaTime);

        if (!canMove)
            return;

        InputMagnitude ();
        

        
    }

    void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * InputZ + right * InputX;

        //if (blockRotationPlayer == false) {
        //transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
        //}
        controller.Move(desiredMoveDirection * Time.deltaTime * velocity);
	}


    void InputMagnitude() {
		//Calculate Input Vectors
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");
        anim.SetFloat("Blend", Speed);

        anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

		//Physically move player
		if (Speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, cam.transform.localEulerAngles.y, 0),smoothRotationTime);
            //transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(transform.localEulerAngles.x, cam.transform.localEulerAngles.y, transform.localEulerAngles.z), smoothRotationTime);
        }
        else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
		}
    }
}
