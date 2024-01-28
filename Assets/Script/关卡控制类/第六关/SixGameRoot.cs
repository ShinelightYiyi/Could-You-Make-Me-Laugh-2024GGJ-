using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SixGameRoot : MonoBehaviour
{
    private static SixGameRoot instance;
    public static SixGameRoot Instance { get => instance; }

    public UIManager rootUIManager;

    private GameObject BG, GameContent;

    [SerializeField] Animator popAni;
    [SerializeField] GameObject popA,POP,mPop,thing,over;
    [SerializeField] CanvasGroup panelB;
    [SerializeField] Animator motherpopAni;

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
        BG = GameObject.FindGameObjectWithTag("BackGround");
        GameContent = GameObject.FindGameObjectWithTag("GameContent");
        
    }

    private void Update()
    {
        BG.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.01f;
        GameContent.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -0.01f;
    }

    private void Start()
    {
        rootUIManager.Push(new ChoicePanelB(), true);
        EventCenter.Instance.EventTrigger("¿ªÊ¼");
        EventCenter.Instance.AddEventListener("Wrong", () => ToWrong());
        EventCenter.Instance.AddEventListener("Nervous", ()=> ToNervous());
        EventCenter.Instance.AddEventListener<int>("Laugh", (o) => EventControl(o));
    }

    private void ToWrong()
    {
        popAni.SetBool("Wrong", true);
        popAni.SetBool("Nervous", false);
    }

    private void ToNervous()
    {
        popAni.SetBool("Nervous", true);
        popAni.SetBool("Wrong", false);
    }

    private void EventControl(int o)
    {
        if(o==2)
        {
            POP.transform.DOScale(0,0.2f).OnComplete(()=>POP.SetActive(false));
            popA.SetActive(true);
            rootUIManager.Pop(false);
            panelB.DOFade(1, 0.5f).OnComplete(() => panelB.interactable = true);
        }
        if(o == 4)
        {
            panelB.DOFade(0, 0.5f).OnComplete(() => panelB.interactable = false);
            popA.transform.DOScale(0, 0.8f);
            mPop.SetActive(true);
            motherpopAni.SetBool("canIn", true);
            Invoke("OverGame", 1f);
        }
    }

    private void OverGame()
    {
        thing.SetActive(true);
        Invoke("OverAni", 0.5f);
    }

    private void OverAni()
    {
        over.SetActive(true);
    }

}
