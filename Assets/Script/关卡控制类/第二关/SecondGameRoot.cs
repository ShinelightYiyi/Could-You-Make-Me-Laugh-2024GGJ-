using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGameRoot : MonoBehaviour
{
    private static SecondGameRoot instance;
    public static SecondGameRoot Instance { get => instance; }

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
    }

    private void Start()
    {
        rootUIManager.Push(new ChoicePanel(), true);
        EventCenter.Instance.EventTrigger("¿ªÊ¼");
        EventCenter.Instance.AddEventListener<int>("Laugh", (o) => CanNotLaugh(o));
    }

    private void CanNotLaugh(int o)
    {
        if(o>=3)
        rootUIManager.Pop(false);
    }

}
