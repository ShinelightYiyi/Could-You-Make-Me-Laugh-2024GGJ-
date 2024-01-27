using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ForthPoint : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler
{
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.tag == "Photo") EventCenter.Instance.EventTrigger("��Ƭ");
        if (gameObject.tag == "Computer") EventCenter.Instance.EventTrigger("����");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.DOScale(1.1f, 0.1f);    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.DOScale(1f, 0.1f);
    }
}
