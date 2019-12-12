using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public Transform prevParent = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        prevParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(prevParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }
}
