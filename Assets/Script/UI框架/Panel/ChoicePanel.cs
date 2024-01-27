using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePanel : BasePanel
{
    private static string name = "ChoicePanel";
    private static string path = "Panel/ChoicePanel";
    public static readonly UIType newUIType = new UIType(name, path);
    public ChoicePanel() : base(newUIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        EventCenter.Instance.AddEventListener("开始", () => GoIn());
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        GoOut();
    }

    private void GoIn()
    {
        GameObject go = GameObject.FindGameObjectWithTag(name);
        //Debug.Log(go.transform.position.x);
        DG.Tweening.Sequence goSequence = DOTween.Sequence(go);
        goSequence.Append(go.transform.DOMoveX(7.79f, 1.5f).SetEase(Ease.OutCubic));
        goSequence.OnComplete(() => EventCenter.Instance.EventTrigger("固定位置"));
    }

    private void GoOut()
    {
        GameObject go = GameObject.FindGameObjectWithTag(name);
        //Debug.Log(go.transform.position.x);
        DG.Tweening.Sequence goSequence = DOTween.Sequence(go);
        goSequence.Append(go.transform.DOMoveX(12f, 1f).SetEase(Ease.OutCubic));
        goSequence.OnComplete(() => GameObject.Destroy(go));
    }
}


