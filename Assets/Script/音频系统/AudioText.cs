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
            if(gameObject.layer == 7)  EventCenter.Instance.EventTrigger<int>("��������", number);
            if (gameObject.layer == 8) EventCenter.Instance.EventTrigger<int>("������Ч", number);
            if (gameObject.layer == 9) EventCenter.Instance.EventTrigger<int>("��������", number);
        }
        if(image.color.a != 0 )
        {
            Debug.Log("����");
            if (gameObject.layer == 7) EventCenter.Instance.EventTrigger<int>("��������", number);
            if (gameObject.layer == 8) EventCenter.Instance.EventTrigger<int>("������Ч", number);
            if (gameObject.layer == 9) EventCenter.Instance.EventTrigger<int>("��������", number);
        }
    }

    private void Awake()
    {
        nameA = transform.name;
        number = int.Parse(nameA);
        image = GetComponent<Image>();
    }

}
