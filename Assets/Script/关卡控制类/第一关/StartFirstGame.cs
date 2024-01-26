using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartFirstGame : MonoBehaviour
{
    [SerializeField] GameObject startFace;

    private void Start()
    {
        ToPosition();
    }

    private void ToPosition()
    {
        DG.Tweening.Sequence startSequence = DOTween.Sequence(startFace);
        startSequence.Append(startFace.transform.DOScale(1f, 0.5f).SetEase(Ease.OutCubic));
        startSequence.Append(startFace.transform.DOMove(new Vector2(-2.40f, 1.13f), 1f).SetEase(Ease.OutCubic));  
        startSequence.OnComplete(() => EventCenter.Instance.EventTrigger("¿ªÊ¼"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Position")
        {
            EventCenter.Instance.EventTrigger("Wrong");
            startFace.SetActive(false);
        }
    }
}
