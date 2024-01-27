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
        startSequence.Append(startFace.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack));
        startFace.transform.DORotate(new Vector3(0, 0, 540), 3f);
        startSequence.Append(startFace.transform.DOMove((startFace.transform.position - new Vector3(-1f,0f)),0.3f).SetEase(Ease.OutBack));
        startSequence.Append(startFace.transform.DOMove(new Vector2(-2.40f, 1.13f), 0.6f).SetEase(Ease.OutQuad));  
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
