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

    private GameObject BG;

    private GameObject GameContent;

    [SerializeField] Animator motherAni;

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
        EventCenter.Instance.AddEventListener<int>("¶ÁÊé" ,(o)=>ChangeEmotion(o));
    }
    private void Update()
    {
        GameContent.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -0.01f;
        BG.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.01f;
    }

    private void ChangeEmotion(int o)
    {
        if(o==3)
        {
            motherAni.SetBool("canIn", true);
            rootUIManager.Push(new BookPanel(), true);
        }
        if(o == 9)
        {
            motherAni.SetBool("canLaugh" , true);
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        rootUIManager.Clear();
        EventCenter.Instance.Clear();
        rootUIManager.Push(new PassPanel(), false);
        Invoke("ReallyChangeScene", 0.5f);
    }

    private void ReallyChangeScene()
    {
        SceneController.Instance.LoadSceneAsyn(new University());
    }


}
