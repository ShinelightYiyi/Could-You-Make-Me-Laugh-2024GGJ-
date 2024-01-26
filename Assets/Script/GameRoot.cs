using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private static GameRoot instance;
    public static GameRoot Instance { get=>instance; }

    public UIManager rootUIManager;

    private Animator laughAni;

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
        DontDestroyOnLoad(gameObject);
        GameObject go = GameObject.FindGameObjectWithTag("NormalCanvas");
        DontDestroyOnLoad(go);
        EventCenter.Instance.AddEventListener("Laugh", () => LaughA());
        EventCenter.Instance.AddEventListener("Bad" ,()=>BadA());
      
    }

    private void Start()
    {
       rootUIManager.Push(new PanelA() ,true);
       laughAni = GameObject.FindGameObjectWithTag("Answer").GetComponent<Animator>();
    }

    private void LaughA()
    {
        Debug.Log("触发Laugh事件");
        laughAni.SetBool("canLaugh", true);
    }

    private void BadA()
    {
        EventCenter.Instance.EventTrigger("加入表情");
        Debug.Log("触发Bad事件");
    }
}
