using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FiveGameRoot : MonoBehaviour
{
    private static FiveGameRoot instance;
    public static FiveGameRoot Instance { get => instance; }

    public UIManager rootUIManager;

    private GameObject BG, GameContent;

    private Image phoneImage;

    [SerializeField] Animator popAni;

    [SerializeField] GameObject mobliePhone,phone,Choice;

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
        phoneImage = mobliePhone.GetComponent<Image>();
        BG = GameObject.FindGameObjectWithTag("BackGround");
        GameContent = GameObject.FindGameObjectWithTag("GameContent");
    }

    private void Start()
    {
        phoneImage.DOFade(0, 1f).OnComplete(()=>phone.transform.DOMoveY(-1.69f,0.5f).SetEase(Ease.OutBack));
        Choice.transform.DOMoveX(7.4f, 1f).OnComplete(() => EventCenter.Instance.EventTrigger("¹Ì¶¨Î»ÖÃ"));
        EventCenter.Instance.AddEventListener("Cry", () => ToLaugh());
        EventCenter.Instance.AddEventListener("Wrong",()=>ToNormal());
         //Debug.Log(Choice.transform.position);
    }

    private void Update()
    {
        BG.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.01f;
        GameContent.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -0.01f;
    }

    private void ToNormal()
    {
        popAni.SetBool("canIn", true);
    }

    private void ToLaugh()
    {
        popAni.SetBool("canLaugh", true);
        Invoke("ReadyChangeScene", 1f);
    }

    private void ReadyChangeScene()
    {
        EventCenter.Instance.Clear();
        rootUIManager.Push(new PassPanel(), false);
        Invoke("ChangeScene", 0.2f);
    }

    private void ChangeScene()
    {
        SceneController.Instance.LoadSceneAsyn(new PassAway());
    }

}
