using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public CinemachineCameraOffset cameraOffset;
    public float smoothTime = 0.3F;
    public float smoothRotationTime = 0.2f;
    public Vector3 offset = new Vector3(0.34f, 0.37f, 4.03f);
    public Vector3 baseOffset = new Vector3(0f, 0f, 0f);
    public Transform player;
    public Transform cam;
    public GameObject aimReticle;
    public float aimMoveSpeed = 5f;
    [Space]
    private Animator anim;
    private CharacterController controller;
    private MovementInput moveInput;
    private Vector3 velocity = Vector3.zero;
    private bool isAiming = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        moveInput = GetComponent<MovementInput>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2")&&moveInput.isGrounded)
        {
            AimAnim(true);
        }
        if(Input.GetButtonUp("Fire2") || (isAiming&&!moveInput.isGrounded))
        {
            AimAnim(false);
            Vector3 rotationVector = player.rotation.eulerAngles;
            rotationVector.x = 0;
            player.rotation = Quaternion.Euler(rotationVector);
        }
        if (isAiming)
        {
            cameraOffset.m_Offset = Vector3.SmoothDamp(cameraOffset.m_Offset, offset, ref velocity, smoothTime);
            player.rotation = Quaternion.Slerp(player.rotation, cam.rotation, smoothRotationTime);
            MoveWhileAiming();
        }
        else
        {
            cameraOffset.m_Offset = Vector3.SmoothDamp(cameraOffset.m_Offset, baseOffset, ref velocity, smoothTime);
        }
    }
    void AimAnim(bool aimState)
    {
        anim.SetBool("isAiming", aimState);
        isAiming = aimState;
        moveInput.blockRotationPlayer = aimState;
        aimReticle.SetActive(aimState);
        moveInput.canMove = !aimState;
    }

    void MoveWhileAiming()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = player.transform.right * x + transform.forward * z;
        controller.Move(move * aimMoveSpeed * Time.deltaTime);
    }
}
