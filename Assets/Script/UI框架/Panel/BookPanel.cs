using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BookPanel : BasePanel
{
    private static string name = "BookPanel";
    private static string path = "Panel/BookPanel";
    public static readonly UIType newUIType = new UIType(name, path);
    public BookPanel() : base(newUIType)
    {

    }


    public override void OnStart()
    {
        base.OnStart();
        GetPanel();
    }


    private void GetPanel()
    {
        GameObject go = GameObject.FindGameObjectWithTag(name);
        go.transform.DOMoveY(go.transform.position.y +0.1f , 0.5f).SetEase(Ease.OutQuad);
    }

}
