using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGameRoot : MonoBehaviour
{
    private static FirstGameRoot instance;
    public static FirstGameRoot Instance { get => instance; }

    public UIManager rootUIManager;

    private GameObject BG;

    private GameObject GameContent;

    [SerializeField] 
    Animator childAni,popAni,motherAni;


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

    private void Start()
    {
        EventCenter.Instance.AddEventListener("Wrong", () => Wrong());
        EventCenter.Instance.AddEventListener("Cry", () => Cry());
        EventCenter.Instance.AddEventListener("Nervous",()=>Nervous());
        EventCenter.Instance.AddEventListener("母亲表情", ()=>Mother());
        EventCenter.Instance.AddEventListener<int>("Laugh",(o)=>Laugh(o));
    }
    
    private void Update()
    {
        BGControl();
    }


    private void BGControl()
    {
        BG.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.01f;
        GameContent.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -0.01f;
    }
    private void Mother()
    {
        motherAni.SetBool("canIn", true);
        rootUIManager.Push(new ChoicePanel(), true);
    }
    private void Wrong()
    {
        popAni.SetBool("Wrong", true);
        popAni.SetBool("Nervous", false);
        popAni.SetBool("Cry", false);
        childAni.SetBool("Wrong", true);
        childAni.SetBool("Cry", false);
        childAni.SetBool("Nervous", false);
        EventCenter.Instance.EventTrigger("母亲表情");
    }

    private void Cry()
    {
        popAni.SetBool("Wrong", false);
        popAni.SetBool("Nervous", false);
        popAni.SetBool("Cry", true);
        childAni.SetBool("Wrong", false);
        childAni.SetBool("Cry", true);
        childAni.SetBool("Nervous", false);
    }

    private void Nervous()
    {
        popAni.SetBool("Wrong", false);
        popAni.SetBool("Nervous", true);
        popAni.SetBool("Cry", false);
        childAni.SetBool("Wrong", false);
        childAni.SetBool("Cry", false);
        childAni.SetBool("Nervous", true);
    }

    private void Laugh(int o)
    {
        if(o>=3)
        {
            motherAni.SetBool("canLaugh", true);
        }
    }
}
