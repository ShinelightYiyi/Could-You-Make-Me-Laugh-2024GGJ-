using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class HoldMove : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
    private bool isDown , isIn;
    private GameObject uiOjbect;
    private Vector3 position;

    private void Start()
    {
        uiOjbect = this.gameObject;
    }

    private void Update()
    {
        if(isDown)
        {
            position = Input.mousePosition;
         //   uiOjbect.transform.DOShakePosition(0.1f, 0.1f);
            uiOjbect.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(position).x , Camera.main.ScreenToWorldPoint(position).y,0) ;

        }
        if(isIn && !isDown)
        {
            uiOjbect .SetActive(false);
            Debug.Log("OK");
            if(uiOjbect.tag == "Laugh")
            {
                EventCenter.Instance.EventTrigger("Laugh");
            }
            if(uiOjbect.tag == "Bad")
            {
                EventCenter.Instance.EventTrigger("Bad");
            }
           // MonoManager.Instance.StartCroutine(ChangeScene());
        }
    }

    /* private IEnumerator ChangeScene()
     {  
         GameRoot.Instance.rootUIManager.Push(new PassPanel());
         yield return new WaitForSeconds(0.2f);
         SceneController.Instance.LoadSceneAsyn(new SceneA());
     }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Position" )
        {
           isIn = true ;    
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Position")
        {
            isIn = false;
        }
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // isDown = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
}
