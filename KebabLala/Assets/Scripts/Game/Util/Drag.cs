using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector2 OriginalPos;
    [SerializeField] private ProductHandler handler;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        handler = GetComponent<ProductHandler>();
        OriginalPos = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Follow the position of the mouse cursor while dragging
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        //transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Disable raycasting and set the alpha of the canvas group to 1
        if (handler.isHandedToCustomer()) 
        {
            GameManager.Instance.EarnMoney(handler.product.price);
        }

        //if(GameManager.Instance.customersInGame)
        rectTransform.anchoredPosition = OriginalPos;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }



}
