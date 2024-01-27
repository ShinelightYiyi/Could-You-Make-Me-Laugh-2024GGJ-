using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BookPanelA : BasePanel
{
    private static string name = "BookPanelA";
    private static string path = "Panel/BookPanelA";
    public static readonly UIType newUIType = new UIType(name, path);
    public BookPanelA() : base(newUIType)
    {

    }

    
}
