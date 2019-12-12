using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTest : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetInteger("SwordSkill",1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetInteger("SwordSkill", 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetInteger("SwordSkill", 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetInteger("SwordSkill", 4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetInteger("SwordSkill", 5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            anim.SetInteger("SwordSkill", 6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            anim.SetInteger("SwordSkill", 7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            anim.SetInteger("SwordSkill", 8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            anim.SetInteger("SwordSkill", 9);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            anim.SetInteger("SwordSkill", 10);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            anim.SetInteger("SwordSkill", 11);
        }

    }
}
