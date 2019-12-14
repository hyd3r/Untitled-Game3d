using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public enum DraggableType
    {
        item,skill
    }
    //public Transform prevParent = null;
    public GameObject canvas;
    public DraggableType dragType = DraggableType.item;
    [Header("If type is Skill")]
    public Skills skill;
    private GameObject skillBar;
    public GameObject[] skillSlot;
    public bool dropSucess = false;
    public string prevPlace;

    void Start()
    {
        skillSlot = new GameObject[10];
        skillBar = GameObject.FindGameObjectWithTag("SkillBar");
        for (int i = 0; i < skillSlot.Length; i++)
        {
            skillSlot[i] = skillBar.transform.GetChild(i).gameObject;
        }
        if (gameObject.transform.childCount>0)
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().text = skill.skillName;
        }

    }
    public GameObject dupe;
    public void OnBeginDrag(PointerEventData eventData)
    {
        DropZone drop = gameObject.transform.parent.GetComponent<DropZone>();
        if (drop != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerSkills[transform.parent.GetSiblingIndex()] = null;
            prevPlace = "Skillslot";
        }
        else
        {
            prevPlace = "Menu";
        }
        dupe = Instantiate(gameObject, canvas.transform);
        dupe.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
        if (dupe.gameObject.transform.childCount>0)
        {
            Destroy(dupe.gameObject.transform.GetChild(0).gameObject);
        }
        //prevParent = transform.parent;
        dupe.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //transform.SetParent(canvas.transform);
       
    }

    public void OnDrag(PointerEventData eventData)
    {


        dupe.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.SetParent(prevParent);
        dupe.GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (!dropSucess && prevPlace.Equals("Skillslot"))
        {
            Destroy(dupe);
            Destroy(gameObject);
        }
        else if (!dropSucess && prevPlace.Equals("Menu"))
        {
            Destroy(dupe);
        }
        else if (dropSucess&&prevPlace.Equals("Skillslot"))
        {
            Destroy(gameObject);
        }
        prevPlace = "";
        dropSucess = false;
    }
}
