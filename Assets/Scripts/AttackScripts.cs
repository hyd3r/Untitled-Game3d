using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScripts : MonoBehaviour
{
    private Animator anim;
    private MovementInput move;
    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<MovementInput>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")&&move.isGrounded)
        {
            anim.SetTrigger("Attack");
        }
       
    }

}
