using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMask : MonoBehaviour
{

    [SerializeField] private Image circleMask;
    [SerializeField] private RectTransform maskCoordinate;

    [SerializeField] private Vector3[] worldMaskCorners = new Vector3[4];

    [SerializeField] private Vector2 offsetMin;
    [SerializeField] private Vector2 offsetMax;

    private Vector2 sizeDeltaManual;
    [SerializeField] private float left, right, top, bot; 
    // Start is called before the first frame update
    void Start()
    {
        tryMaskRect();

    }

    private void tryMaskRect()
    {

        maskCoordinate.GetWorldCorners(worldMaskCorners);
    }

    public void SetEnablMask(bool isEnable)
    {
        circleMask.enabled = isEnable;
    }

    public void SetMaskPosition(ref Vector3 positionRef) 
    {
        circleMask.gameObject.transform.position = positionRef + new Vector3(200.0f, 0.0f, circleMask.gameObject.transform.position.z);
    }

    public void SetMaskSize() 
    {
        offsetMin.x = left;
        offsetMax.x = -right;
        offsetMax.y = -top;
        offsetMin.y = bot;

        maskCoordinate.offsetMin = offsetMin;
        maskCoordinate.offsetMax = offsetMax;
    }

    public void SetMaskSize(ref Vector4 offset)
    {
        offsetMin.x = offset.x;
        offsetMax.x = -offset.z;
        offsetMax.y = -offset.y;
        offsetMin.y = offset.w;

        maskCoordinate.offsetMin = offsetMin;
        maskCoordinate.offsetMax = offsetMax;
    }

    public void SetMaskWidthHeight(Vector2 widhei)
    {
        maskCoordinate.sizeDelta = widhei;
    }

    public void SetMaskSize(float _width, float _height)
    {
        sizeDeltaManual.x = _width;
        sizeDeltaManual.y = _height;

        maskCoordinate.sizeDelta = sizeDeltaManual;
    }
}
