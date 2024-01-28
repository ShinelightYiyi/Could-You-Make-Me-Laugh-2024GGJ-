using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Introduce : MonoBehaviour
{
    public GameObject go;

    public void Down()
    {
        go.SetActive(true);
        go.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            go.SetActive(false);
        }
    }
}
