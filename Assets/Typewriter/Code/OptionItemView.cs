using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionItemView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;


    public void SetText(string value)
    {
        _text.text = value;
    }

    public void SetButtonAction(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }
}
