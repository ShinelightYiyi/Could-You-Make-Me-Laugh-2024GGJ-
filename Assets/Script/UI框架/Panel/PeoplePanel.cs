using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeoplePanel : BasePanel
{
    private static string name = "People";
    private static string path = "Panel/People";
    public static readonly UIType newUIType = new UIType(name, path);
    public PeoplePanel() : base(newUIType)
    {
    }
}
