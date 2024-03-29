using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HoldInput : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler ,IPointerExitHandler,IPointerEnterHandler
{
    private bool isDown = false;
    private static float pointTime = 0f;


    private void Update()
    {
        if(isDown)
        {
            pointTime += Time.deltaTime;
            if(pointTime >= 0.1f)
            {
                EventCenter.Instance.EventTrigger<float>("����" , pointTime -0.1f) ;
                if(pointTime-0.1f >0.71f )
                {
                    GameObject.Destroy(gameObject);
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isDown = false;
        pointTime = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        pointTime = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        pointTime = 0;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isDown = false;
        pointTime = 0;
        gameObject.transform.DOScale(1f, 0.1f);
        // Debug.LogWarning("A");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.DOScale(1.1f, 0.1f);
    }
}
