using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SeconLaugh : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    bool canTriggerEvent;
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.transform.DOScale(1f, 0.1f);
        if (!canTriggerEvent)
        {
            canTriggerEvent = true;
            EventCenter.Instance.EventTrigger("ToLaugh");
        }
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
