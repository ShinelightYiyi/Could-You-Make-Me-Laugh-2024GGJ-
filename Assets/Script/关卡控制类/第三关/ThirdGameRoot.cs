using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ThirdGameRoot : MonoBehaviour
{
    private static ThirdGameRoot instance;
    public static ThirdGameRoot Instance { get => instance; }

    public UIManager rootUIManager;


    public void Awake()
    {
        rootUIManager = new UIManager();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        rootUIManager.Push(new BookPanelA(), true);
    }

    private void Start()
    {
        EventCenter.Instance.AddEventListener<float>( "³¤°´",(o) => ControlSlider(o));
    }
     
    private void ControlSlider(float o)
    {
        GameObject slider = GameObject.FindGameObjectWithTag("Slider");
        GameObject go  = UIMethod.Instance.FindObjectInChild(slider , "Image");
     //   Debug.Log(go.transform.position.y);
        if (go.transform.position.y < 0.05f)
        {
            go.transform.DOMoveY(go.transform.position.y + 0.1f, 0.1f);
        }

   
        if(go.transform.position.y >= -1.46)
        {
            slider.transform.DOShakePosition(0.1f);
        }
    }

}
