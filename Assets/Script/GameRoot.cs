using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameRoot : MonoBehaviour
{
    private static GameRoot instance;
    public static GameRoot Instance { get=>instance; }

    public UIManager rootUIManager;

    public GameObject AudioManager;

    public GameObject Setting;

    private bool isSetting;
    private bool canSet;
    public void Awake()
    {
        rootUIManager = new UIManager();

        if(instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        GameObject go = GameObject.FindGameObjectWithTag("NormalCanvas");
        DontDestroyOnLoad(go);
        DontDestroyOnLoad(AudioManager);
        isSetting = false;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            isSetting = !isSetting;
            canSet = true;
        }
        Set();
        Debug.Log(Setting.transform.position);
    }

    private void Set()
    {
        if (isSetting && canSet)
        {
            Setting.transform.DOMoveY(257.85f, 0.2f);
          //  Debug.Log(Setting.transform.position);
            canSet = false;
        }
        if (!isSetting && canSet)
        {
          //  Debug.Log(Setting.transform.position);
            Setting.transform.DOMoveY(-492.15f, 0.2f).SetEase(Ease.InBack);
            canSet = false;
        }
    }

}
