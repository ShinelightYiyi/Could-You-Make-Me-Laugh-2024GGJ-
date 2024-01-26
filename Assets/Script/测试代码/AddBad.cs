using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AddBad : MonoBehaviour
{
    private  int index = 0;

    private void Start()
    {
        EventCenter.Instance.AddEventListener("加入表情" , ()=>BadAction());
        index = 0;
    }
    private void BadAction()
    {
        index++;
        if(index >= 3)
        {
            GameObject panelA = GameObject.FindGameObjectWithTag("PanelA");
            GameObject go = UIMethod.Instance.FindObjectInChild(panelA, "D");
            Image goImage = go.GetComponent<Image>();
            goImage.DOFade(1f, 0.5f);
        }

    }
}
