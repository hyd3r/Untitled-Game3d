using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Draggable drag = eventData.pointerDrag.GetComponent<Draggable>();
        if (drag != null)
        {
            if (drag.dragType == Draggable.DraggableType.skill)
            {
                PlayerStats playerstat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
                int existingSkill = playerstat.CheckSkill(drag.skill);
                if (existingSkill >= 0)
                {
                    playerstat.playerSkills[transform.GetSiblingIndex()] = drag.skill;
                    drag.dupe.transform.SetParent(this.transform);
                    playerstat.playerSkills[existingSkill] = null;
                    foreach (Transform child in drag.skillSlot[existingSkill].transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    drag.dropSucess = true;
                }
                else
                {
                    playerstat.playerSkills[transform.GetSiblingIndex()] = drag.skill;
                    drag.dupe.transform.SetParent(this.transform);
                    drag.dropSucess = true;
                }
            }
        }
    }
}
