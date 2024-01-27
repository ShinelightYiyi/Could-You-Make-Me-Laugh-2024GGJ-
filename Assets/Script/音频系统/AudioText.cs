using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class AudioText : MonoBehaviour ,IPointerDownHandler
{
    private string nameA;
    private int number;
    private Image image;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(number);
        
        if(image.color.a == 0 )
        {
            if(gameObject.layer == 7)  EventCenter.Instance.EventTrigger<int>("增加音量", number);
            if (gameObject.layer == 8) EventCenter.Instance.EventTrigger<int>("增加音效", number);
            if (gameObject.layer == 9) EventCenter.Instance.EventTrigger<int>("增加音乐", number);
        }
        if(image.color.a != 0 )
        {
            Debug.Log("减少");
            if (gameObject.layer == 7) EventCenter.Instance.EventTrigger<int>("减少音量", number);
            if (gameObject.layer == 8) EventCenter.Instance.EventTrigger<int>("减少音效", number);
            if (gameObject.layer == 9) EventCenter.Instance.EventTrigger<int>("减少音乐", number);
        }
    }

    private void Awake()
    {
        nameA = transform.name;
        number = int.Parse(nameA);
        image = GetComponent<Image>();
    }

}
