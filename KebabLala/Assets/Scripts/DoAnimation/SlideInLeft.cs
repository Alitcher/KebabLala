using DG.Tweening;
using UnityEngine;

public class SlideInLeft : MonoBehaviour
{
    [SerializeField] private float source = -500f; // Start from off-screen on the left
    [SerializeField] private float target = 0f; // End position
    [SerializeField] private float duration = 4.0f;

    [SerializeField] private RectTransform rectTransform;

    private void Awake()
    {
        DOTween.Init();
    }

    private void OnEnable()
    {
        SlideIn();
    }

    public void SlideIn()
    {
        // Set initial position
        rectTransform.anchoredPosition = new Vector2(source, rectTransform.anchoredPosition.y);

        // Perform the slide animation using DOAnchorPosX
        rectTransform.DOAnchorPosX(target, duration)
                     .SetEase(Ease.OutQuad)
                     .SetUpdate(true);  // This will make the tween ignore Time.timeScale
    }

    public void SlideOut()
    {
        rectTransform.DOAnchorPosX(source, duration)
                     .SetEase(Ease.InQuad)
                     .SetUpdate(true);  // This will make the tween ignore Time.timeScale
    }
}
