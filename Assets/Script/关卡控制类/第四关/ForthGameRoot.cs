using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ForthGameRoot : MonoBehaviour
{
    private static ForthGameRoot instance;
    public static ForthGameRoot Instance { get => instance; }

    public UIManager rootUIManager;

    private GameObject BG, GameContent;

    [SerializeField] GameObject Photo1, Photo2,Panel,Pop;
    [SerializeField] GameObject MobilePhone,PanelA,newPop,laughPop;
    [SerializeField] Animator phoneAni;

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
        EventCenter.Instance.AddEventListener("照片", PhotoGo);
       EventCenter.Instance.AddEventListener<int>("开始内容" ,(o)=>LetStart(o));
        BG = GameObject.FindGameObjectWithTag("BackGround");
        GameContent = GameObject.FindGameObjectWithTag("GameContent");
        EventCenter.Instance.AddEventListener("固定位置", () => Phone());
        EventCenter.Instance.AddEventListener<int>("Laugh", (o) => Know(o));
    }

    private void Update()
    {
        BG.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.01f;
        GameContent.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -0.01f;
    }
    private void PhotoGo()
    {
        DG.Tweening.Sequence p1Sequence = DOTween.Sequence(Photo1);
        p1Sequence.Append(Photo1.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack));
        p1Sequence.Append(Photo1.transform.DOMoveX(Photo1.transform.position.x - 1f, 0.5f).SetEase(Ease.OutBack));
        Photo1.transform.DORotate(new Vector3(0, 0, 110f), 0.8f).SetEase(Ease.OutQuad);
        p1Sequence.Append(Photo1.transform.DOMoveX(Photo1.transform.position.x + 20f, 1f).SetEase(Ease.OutBack));       

        DG.Tweening.Sequence p2Sequence = DOTween.Sequence(Photo2);
        p2Sequence.Append(Photo2.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack));
        p2Sequence.Append(Photo2.transform.DOMoveX(Photo1.transform.position.x - 1f, 0.5f).SetEase(Ease.OutBack));
        Photo2.transform.DORotate(new Vector3(0, 0, 80f), 0.8f).SetEase(Ease.OutQuad);
        p2Sequence.Append(Photo2.transform.DOMoveX(Photo1.transform.position.x + 20f, 1f).SetEase(Ease.OutBack));

        Pop.SetActive(false);
    }

    private void LetStart(int o)
    {
        if(o>=2)
        Panel.transform.DOMoveX(7.58f, 1.5f).OnComplete(() => EventCenter.Instance.EventTrigger("固定位置"));
    }

    private void Phone()
    {
        MobilePhone.SetActive(true);
        PanelA.SetActive(true);
        MobilePhone.transform.DOMoveY(-2.13f, 1f).SetEase(Ease.OutBack).OnComplete(()=>newPop.SetActive(true));
    }

    private void Know(int o )
    {
        if(o==1)
        {
            phoneAni.SetBool("First", true);
        }
        else if(o==2) 
        {
            phoneAni.SetBool("Second", true);
        }
        else if(o==3)
        {
            phoneAni.SetBool("Third", true);
            laughPop.SetActive(true);
        }

    }

}
