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

    private GameObject inputObj;

    private bool canTrigger;

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
   
    }

    private void Start()
    {
        EventCenter.Instance.AddEventListener<float>( "³¤°´",(o) => ControlSlider(o));
        inputObj = GameObject.FindGameObjectWithTag("Input");
    }

    private void ControlSlider(float o)
    {
        GameObject slider = GameObject.FindGameObjectWithTag("Slider");
        GameObject go  = UIMethod.Instance.FindObjectInChild(slider , "Image");
        Image goImage = inputObj.GetComponent<Image>();
     //   Debug.Log(go.transform.position.y);
        if (go.transform.position.y < 0.05f)
        {
            canTrigger = true;
            go.transform.DOMoveY(go.transform.position.y + 0.1f, 0.1f);
        }
        else if(go.transform.position.y >= 0.1)
        {
            if (canTrigger)
            {    
                Debug.LogWarning("´¥·¢");
                go.transform.position = new Vector3(go.transform.position.x, -2.42f, 0);
                goImage.color = new Color(Random.value, Random.value, Random.value);
                canTrigger = false;
            }
        }


        if(go.transform.position.y >= -1.46)
        {
            slider.transform.DOShakePosition(0.1f);
        }
    }

}
