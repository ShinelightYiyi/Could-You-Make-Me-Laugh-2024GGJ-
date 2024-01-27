using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ForthPoint : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler
{
    private static int index;

    private void Start()
    {
        index = 0;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.tag == "Photo") EventCenter.Instance.EventTrigger("��Ƭ");
        if (gameObject.tag == "Computer") EventCenter.Instance.EventTrigger("����");
        index++;
        EventCenter.Instance.EventTrigger<int>("��ʼ����", index);
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
