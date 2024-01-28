using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FiveInput : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ani.SetBool("isDown", true);
        EventCenter.Instance.EventTrigger("µã»÷"+gameObject.name);
        ani.SetBool("isDown", false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ani.SetBool("isEnter", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ani.SetBool("isEnter", false);
    }
}
