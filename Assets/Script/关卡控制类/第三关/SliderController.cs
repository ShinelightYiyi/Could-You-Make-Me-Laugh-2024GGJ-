using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SliderController : MonoBehaviour
{
    private Transform imageTra;
    private static int index;
    private void Start()
    {
        index = 0;
        imageTra = UIMethod.Instance.FindObjectInChild(this.gameObject, "Image").transform;
        Debug.Log(imageTra.position.x);
        EventCenter.Instance.AddEventListener<float>("≥§∞¥", (o) => SliderIn(o));
    }


    private void SliderIn(float o)
    {
        if (imageTra.position.x >= -1.87f)
        {
            imageTra.DOMoveX(imageTra.position.x - 0.1f, 0.1f);
        }
        if(imageTra.position.x>=-1)
        {
            this.gameObject.transform.DOShakePosition(0.1f);
        }

        if(o>=0.71f)
        {
            imageTra.position = new Vector3(-0.1f, imageTra.position.y, 0);
            index++;
            EventCenter.Instance.EventTrigger<int>("∂¡ È", index);
        }
     //   Debug.Log(imageTra.position.x); 
    }

}
