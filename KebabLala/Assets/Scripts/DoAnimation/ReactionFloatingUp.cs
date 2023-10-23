using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ReactionFloatingUp : MonoBehaviour
{
    [SerializeField] private RectTransform reaction;
    [SerializeField] private Image reactionImage;
    private float moveYAmount = 50f;

    void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        // Reset alpha to 1
        reactionImage.color = new Color(reactionImage.color.r, reactionImage.color.g, reactionImage.color.b, 1f);

        reaction.DOLocalMoveY(reaction.localPosition.y + moveYAmount, 1f).SetEase(Ease.OutCubic);

        reactionImage.DOFade(0f, 0.3f).SetDelay(0.7f).OnComplete(() =>
        {
            // Optional: Reset position
            reaction.localPosition = new Vector3(reaction.localPosition.x, reaction.localPosition.y - moveYAmount, reaction.localPosition.z);
        });
    }
}
