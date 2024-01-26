using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelA : BasePanel
{
    private static string name = "PanelA";
    private static string path = "Panel/PanelA";
    private static readonly UIType newUIType = new UIType(name, path);
    public PanelA() : base(newUIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        PanelAIn();
    }

    private void PanelAIn()
    {
        GameObject go = GameObject.FindGameObjectWithTag(name);
        DG.Tweening.Sequence goSequence = DOTween.Sequence(go);
        goSequence.Append(go.transform.DOMoveX(6.25f, 0.5f).SetEase(Ease.OutCubic));
    }
}
