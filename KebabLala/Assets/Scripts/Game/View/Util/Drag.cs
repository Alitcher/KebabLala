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

        //if (!TryGetComponent(out handler))
        //{
        //    Debug.LogError("ProductHandler component not found on GameObject");
        //}
        //else
        //{
        //    // Do something with the handler component
        //}

        OriginalPos = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Follow the position of the mouse cursor while dragging
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //plate on table only use this function
    public void SetHandler(ref ProductHandler customerProducthandler) 
    {
        handler = customerProducthandler;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (handler == null)
            return;

        // Disable raycasting and set the alpha of the canvas group to 1

        bool match = handler.isValidToCustomer();

        //if(GameManager.Instance.customersInGame)
        rectTransform.anchoredPosition = OriginalPos;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }



}
