using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class MuteVule : MonoBehaviour, IPointerDownHandler
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();  
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(image.color.a == 0)
        {
            image.DOFade(1f, 0.01f);
            if (gameObject.layer == 7) EventCenter.Instance.EventTrigger<int>("增加音量", 10);
            if (gameObject.layer == 8) EventCenter.Instance.EventTrigger<int>("增加音效", 10);
            if (gameObject.layer == 9) EventCenter.Instance.EventTrigger<int>("增加音乐",10);
        }
        else if(image.color.a == 1)
        {
            image.DOFade(0f, 0.01f);
            if (gameObject.layer == 7) EventCenter.Instance.EventTrigger<int>("减少音量", 0);
            if (gameObject.layer == 8) EventCenter.Instance.EventTrigger<int>("减少音效", 0);
            if (gameObject.layer == 9) EventCenter.Instance.EventTrigger<int>("减少音乐", 0);
        }

    }
}
