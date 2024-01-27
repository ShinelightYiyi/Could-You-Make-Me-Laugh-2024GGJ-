using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice3Panel : BasePanel
{
    private static string name = "ChoicePanel3";
    private static string path = "Panel/ChoicePanel 3";
    public static readonly UIType newUIType = new UIType(name, path);
    public Choice3Panel() : base(newUIType)
    {

    }
}
