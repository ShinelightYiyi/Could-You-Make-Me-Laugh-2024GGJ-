using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;
using DG.Tweening;
using UnityEngine.UI;

public class SecondGameRoot : MonoBehaviour
{
    private static SecondGameRoot instance;
    public static SecondGameRoot Instance { get => instance; }

    public UIManager rootUIManager;

    private GameObject BG;
    private GameObject GameContent;

    [SerializeField]
    GameObject Thing;
    [SerializeField]
    Animator childAni,motherAni;
    [SerializeField] GameObject Other;

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
        rootUIManager.Push(new ChoicePanel(), true);
        EventCenter.Instance.EventTrigger("开始");
        EventCenter.Instance.AddEventListener<int>("Laugh", (o) => CanNotLaugh(o));
        EventCenter.Instance.AddEventListener("Wrong", () => Wrong());
        EventCenter.Instance.AddEventListener("Cry", () => Cry());
        EventCenter.Instance.AddEventListener("Nervous", () => Nervous());
        EventCenter.Instance.AddEventListener("ToLaugh", () => Laugh());
    }

    private void Update()
    {
        BGControl();
    }

    private void CanNotLaugh(int o)
    {
        if (o >= 3)
        {
            rootUIManager.Pop(false);
            GameObject go = GameObject.FindGameObjectWithTag("Position");
            DG.Tweening.Sequence goSequence = DOTween.Sequence(go);
            goSequence.Append(go.transform.DOScale(1.3f, 0.1f).SetEase(Ease.InCubic));
            goSequence.Append(go.transform.DOScale(0f, 0.4f).SetEase(Ease.InOutQuad));
            Question();
            Other.SetActive(true);
        }
    }

    private void BGControl()
    {
        BG.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.01f;
        Thing.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.01f;
        GameContent.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -0.01f;
    }


    private void Wrong()
    {
        childAni.SetBool("Wrong", true);
        childAni.SetBool("Cry", false);
        childAni.SetBool("Nervous", false);
        EventCenter.Instance.EventTrigger("母亲表情");
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


    private void Question()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Answer");
        Image image = go.GetComponent<Image>();
        image.DOFade(1f, 0.5f).SetEase(Ease.OutQuad);
    }


    private void Laugh()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Answer");
        Image image = go.GetComponent<Image>();
        image.DOFade(1f, 0.5f).SetEase(Ease.OutQuad).OnComplete(() => motherAni.SetBool("canLaugh", true));
        Invoke("LastScene", 1.5f);
    }

   
    private void LastScene()
    {
        rootUIManager.Push(new PassPanel(), false);
        
        Invoke("ChangeScene", 0.2f);
    //    rootUIManager.Pop(true);
    }
    private void ChangeScene()
    {
        SceneController.Instance.LoadSceneAsyn(new StudentScene());
        Invoke("ClearEvent", 0.5f);
    }

    private void ClearEvent()
    {
        EventCenter.Instance.Clear();
    }
}
