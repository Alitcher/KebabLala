using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextKeyPair : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] protected TextMeshProUGUI description;

    public void SetTitle(ref string _title)
    {
        title.text = _title;

    }

    public void SetDescription(ref string _description)
    {
        description.text = _description;

    }

    public void SetPair(ref string _title, ref string _description)
    {
        SetTitle(ref _title);
        SetDescription(ref _description);
    }

    public void SetIcon(Sprite _icon)
    {
        icon.sprite = _icon;
    }
}
