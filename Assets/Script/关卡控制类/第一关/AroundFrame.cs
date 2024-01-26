using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AroundFrame : MonoBehaviour
{
    private float timer = 0;
    private UnityEngine.UI.Image image;
    [SerializeField] Sprite[] imageSprite;

    private void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer>= 8*Time.fixedDeltaTime)
        {
            timer = 0;
            Sprite randomSprite = imageSprite[Random.Range(0, imageSprite.Length)];
            image.sprite = randomSprite;
        }
    }
}
