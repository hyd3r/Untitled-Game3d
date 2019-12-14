using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public string playerName;
    public int playerXP=0;
    public int playerLevel=1;
    public int playerHP=50;
    private Animator anim;

    [Header("Player Attributes")]
    public List<PlayerAttributes> Attributes = new List<PlayerAttributes>();

    [Header("Player Skills Enabled")]
    public List<Skills> playerSkills = new List<Skills>();

    void Start()
    {
        anim=GetComponent<Animator>();
    }
    
    public int CheckSkill(Skills skill)
    {
        for (int i = 0; i < playerSkills.Count; i++)
        {
            if (skill == playerSkills[i])
            {
                return i;
            }
        }
        return -1;
    }

    void Update()
    {
        SkillHotkeys();
       
    }

    void SkillHotkeys() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (playerSkills[0] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[0].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerSkills[1] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[1].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (playerSkills[2] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[2].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (playerSkills[3] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[3].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (playerSkills[4] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[4].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (playerSkills[5] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[5].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (playerSkills[6] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[6].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (playerSkills[7] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[7].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (playerSkills[8] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[8].skillID);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (playerSkills[9] != null)
            {
                anim.SetInteger("SwordSkill", playerSkills[9].skillID);
            }
        }
    }
}
