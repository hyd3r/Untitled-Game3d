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
            drag.prevParent = this.transform;
        }
    }
}
