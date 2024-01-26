using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private static GameRoot instance;
    public static GameRoot Instance { get=>instance; }

    public UIManager rootUIManager;

    public void Awake()
    {
        rootUIManager = new UIManager();

        if(instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        GameObject go = GameObject.FindGameObjectWithTag("NormalCanvas");
        DontDestroyOnLoad(go);

      
    }




}
