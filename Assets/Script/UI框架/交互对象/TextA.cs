using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextA : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject Slider;
    private void CanHold(float inputTime)
    {
        if(inputTime == 0)
        {
            Debug.LogWarning("OK");
        }
        if(inputTime >=1 )
        {
           // Debug.Log(cube.transform.position.y);
            if (cube.transform.position.y <= 0.025f)
            {
                cube.transform.DOMoveY(cube.transform.position.y + 0.05f, 0.1f);
                if(cube.transform.position.y >= -1.21f)
                {
                    Slider.transform.DOShakePosition(0.1f, 0.15f);
                }
            }
           // Debug.Log(inputTime);
          text.text = inputTime.ToString();

        }
    }

    private void Awake()
    {
        EventCenter.Instance.AddEventListener<float>("³¤°´", (o) => CanHold(o));
    }
}
