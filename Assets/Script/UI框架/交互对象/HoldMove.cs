using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class HoldMove : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
    private bool isDown , isIn,isStart;
    private GameObject uiOjbect;
    private Vector3 position;
    private Animator ani;
    private Vector2 normalPosition;
    private GameObject positonObject;
    private static int index;

    private void Start()
    {
        index = 0;
        uiOjbect = this.gameObject;     
        ani = gameObject.GetComponent<Animator>();
        positonObject = GameObject.FindGameObjectWithTag("Position");
        EventCenter.Instance.AddEventListener("¹Ì¶¨Î»ÖÃ", () => GetPositon());
    }

    private void Update()
    {
        if(isDown)
        {
            position = Input.mousePosition;
         //   uiOjbect.transform.DOShakePosition(0.1f, 0.1f);
            uiOjbect.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(position).x , Camera.main.ScreenToWorldPoint(position).y,0) ;
            ani.SetBool("isDown", true);
        }
        else
        {
            ani.SetBool("isDown", false);
            if(isStart)   gameObject.transform.DOMove(normalPosition, 0.2f).SetEase(Ease.OutCubic);
        }


        if (positonObject != null)
        {
            if (isIn)
            {
                positonObject.transform.DOScale(1.1f, 0.2f);
             //   Debug.Log("OK");
            }
            else
            {
                positonObject.transform.DOScale(1f, 0.2f);
            }
        }

        if(isIn && !isDown)
        {
            uiOjbect .SetActive(false);
            Debug.Log("OK");
            if(uiOjbect.tag == "Cry")
            {
                EventCenter.Instance.EventTrigger("Cry");
            }
            if(uiOjbect.tag == "Nervous")
            {
                EventCenter.Instance.EventTrigger("Nervous");
            }
            if(uiOjbect.tag == "Wrong")
            {
                EventCenter.Instance.EventTrigger("Wrong");
            }
            index++;
            Debug.Log(index);
            EventCenter.Instance.EventTrigger<int>("Laugh", index);
        }
    }

    private void GetPositon()
    {
        normalPosition = uiOjbect.transform.position;
        isStart = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Position" )
        {
           isIn = true ;    
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Position")
        {
            isIn = false;
        }
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // isDown = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
}
