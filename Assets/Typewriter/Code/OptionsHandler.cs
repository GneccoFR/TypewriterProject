using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;

public class OptionsHandler : MonoBehaviour
{
    [SerializeField] private OptionItemView _optionView;
    [SerializeField] private RectTransform _bubbleRect;
    private List<OptionItemView> _cachedOptionViews = new List<OptionItemView>();


    private void OnDisable()
    {
        ClearAllOptions();
    }


    public void DisplayOptions(List<string> messages, List<UnityAction> actions)
    {
        if (messages.Count != actions.Count)
        {
            Debug.LogError("amount of Messages and Actions must match!!!");
            return;
        }

        if (_cachedOptionViews.Count != 0)
        {
            if (messages.Count > _cachedOptionViews.Count)
                InstantiateNewOptions(messages.Count - _cachedOptionViews.Count);
        }
        else
            InstantiateNewOptions(messages.Count);

        for (int i = 0; i < _cachedOptionViews.Count; i++)
        {
            if (i > messages.Count)
                _cachedOptionViews[i].gameObject.SetActive(false);
            else
                _cachedOptionViews[i].gameObject.SetActive(true);
        }

        SetOptionsData(messages, actions);

        _optionView.gameObject.SetActive(false);
    }

    private void InstantiateNewOptions(int value)
    {
        for (int i = 0; i <= value; i++)
        {
            var GOinstance = Instantiate(_optionView.gameObject, _bubbleRect);
            OptionItemView optionInstance = GOinstance.GetComponent<OptionItemView>();
            _cachedOptionViews.Add(optionInstance);
        }
    }

    private void SetOptionsData(List<string> messages, List<UnityAction> actions)
    {
        for (int i = 0; i < messages.Count; i++)
        {
            _cachedOptionViews[i].SetButtonAction(actions[i]);
            _cachedOptionViews[i].SetText(messages[i]);
        }
    }

    private void ClearAllOptions()
    {
        for (int i = 0; i < _cachedOptionViews.Count; i++)
        {
            _cachedOptionViews[i].ClearListener();
            _cachedOptionViews[i].SetText(string.Empty);
            _cachedOptionViews[i].gameObject.SetActive(false);
        }
    }
}
