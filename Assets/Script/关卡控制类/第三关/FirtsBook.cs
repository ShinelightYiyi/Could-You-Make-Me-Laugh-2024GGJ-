using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirtsBook : MonoBehaviour
{

    private void Start()
    {
        EventCenter.Instance.AddEventListener<float>("³¤°´", (o) => ChangePanel(o));        
    }


    private void ChangePanel(float o)
    {
        if(o>=0.92f)
        {
            ThirdGameRoot.Instance.rootUIManager.Pop(true);
            ThirdGameRoot.Instance.rootUIManager.Push(new BookPanelA(), true);
        }
    }
}
