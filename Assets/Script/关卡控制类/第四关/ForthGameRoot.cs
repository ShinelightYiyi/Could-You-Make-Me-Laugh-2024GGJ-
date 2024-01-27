using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ForthGameRoot : MonoBehaviour
{
    private static ForthGameRoot instance;
    public static ForthGameRoot Instance { get => instance; }

    public UIManager rootUIManager;

    [SerializeField] GameObject Photo1, Photo2,Panel,Pop;

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
        EventCenter.Instance.AddEventListener("’’∆¨", PhotoGo);
        Panel.transform.DOMoveX(7.58f, 1.5f);
    }

    private void PhotoGo()
    {
        DG.Tweening.Sequence p1Sequence = DOTween.Sequence(Photo1);
        p1Sequence.Append(Photo1.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack));
        p1Sequence.Append(Photo1.transform.DOMoveX(Photo1.transform.position.x - 1f, 0.2f).SetEase(Ease.OutBack));
        Photo1.transform.DORotate(new Vector3(0, 0, 110f), 0.8f).SetEase(Ease.OutQuad);
        p1Sequence.Append(Photo1.transform.DOMoveX(Photo1.transform.position.x + 20f, 1f).SetEase(Ease.OutBack));

        DG.Tweening.Sequence p2Sequence = DOTween.Sequence(Photo2);
        p2Sequence.Append(Photo2.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack));
        p2Sequence.Append(Photo2.transform.DOMoveX(Photo1.transform.position.x - 1f, 0.2f).SetEase(Ease.OutBack));
        Photo2.transform.DORotate(new Vector3(0, 0, 80f), 0.8f).SetEase(Ease.OutQuad);
        p2Sequence.Append(Photo2.transform.DOMoveX(Photo1.transform.position.x + 20f, 1f).SetEase(Ease.OutBack));

        Pop.SetActive(false);
    }


}
