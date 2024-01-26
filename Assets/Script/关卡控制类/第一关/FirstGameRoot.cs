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

    [SerializeField] Animator childAni;

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
        rootUIManager.Push(new ChoicePanel(), true);
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
    private void Wrong()
    {
        childAni.SetBool("Wrong", true);
        childAni.SetBool("Cry", false);
        childAni.SetBool("Nervous", false);
    }

    private void Cry()
    {
        childAni.SetBool("Wrong", false);
        childAni.SetBool("Cry", true);
        childAni.SetBool("Nervous", false);
    }

    private void Nervous()
    {
        childAni.SetBool("Wrong", false);
        childAni.SetBool("Cry", false);
        childAni.SetBool("Nervous", true);
    }

}
