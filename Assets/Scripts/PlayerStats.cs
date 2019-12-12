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

    [Header("Player Attributes")]
    public List<PlayerAttributes> Attributes = new List<PlayerAttributes>();

    [Header("Player Skills Enabled")]
    public List<Skills> playerSkills = new List<Skills>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
