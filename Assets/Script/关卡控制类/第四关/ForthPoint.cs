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
        if (gameObject.tag == "Photo") EventCenter.Instance.EventTrigger("照片");
        if (gameObject.tag == "Computer") EventCenter.Instance.EventTrigger("电脑");
        index++;
        EventCenter.Instance.EventTrigger<int>("开始内容", index);
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
