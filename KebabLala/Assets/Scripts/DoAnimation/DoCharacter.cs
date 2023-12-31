using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoCharacter : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField][Range(0,2.0f)] private float idleMovementAmount = 0.25f; // How much the character moves up and down
    [SerializeField] private float idleDuration = 1f; // Duration of one movement cycle
    [SerializeField] private Vector3 originalPosition;

    public void SetPos()
    {
        // Get the original position of the character
        originalPosition = character.transform.localPosition;
    }

    public void DoIdle()
    {
        // Move the character up and down repeatedly
        character.transform.DOLocalMoveY(originalPosition.y + idleMovementAmount, idleDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    public void DoProductHanding() 
    {
        Sequence productHandingSequence = DOTween.Sequence();

        // Anticipation: Character leans forward a bit
        productHandingSequence.Append(character.transform.DOLocalMoveY(originalPosition.y - idleMovementAmount, (idleDuration + 1) * 12))
            .SetEase(Ease.OutSine);

        // Excitement: Character quickly moves up to show they're ready to receive the product
        productHandingSequence.Append(character.transform.DOLocalMoveY(originalPosition.y + idleMovementAmount, (idleDuration + 1) * 12))
            .SetEase(Ease.InSine);

        // Return to idle: Character goes back to original position
        productHandingSequence.Append(character.transform.DOLocalMoveY(originalPosition.y, (idleDuration + 1) * 12))
            .SetEase(Ease.OutSine);

        // Play the sequence
        productHandingSequence.Play();
    }

    public void DoUpset() 
    {
    
    }

    float jumpHeight = 5.5f; // Height of the jump, you can adjust this as needed
    float jumpDuration = 0.1f; // Duration of each jump, you can adjust this as needed
    public void DoCompleteOrder()
    {
        Sequence completeOrderSequence = DOTween.Sequence();

        for (int i = 0; i < 4; i++)
        {
            // Jump up
            completeOrderSequence.Append(character.transform.DOLocalMoveY(originalPosition.y + jumpHeight, jumpDuration)
                .SetEase(Ease.OutQuad));

            // Fall down
            completeOrderSequence.Append(character.transform.DOLocalMoveY(originalPosition.y, jumpDuration)
                .SetEase(Ease.InQuad));
        }

        // Play the sequence
        completeOrderSequence.Play();
    }

}
