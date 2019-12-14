using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Create Skill")]
public class Skills : ScriptableObject
{
    public int skillID;
    public string skillName;
    public string description;
    public Sprite icon;
    public int levelNeeded;
    public int skillPointNeeded;

    public List<PlayerAttributes> affectedAttributes = new List<PlayerAttributes>();
}
