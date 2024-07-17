using System;
using System.Collections;
using System.Collections.Generic;
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


    internal void DisplayOptions(List<string> messages, List<UnityAction> actions)
    {
        if (messages.Count != actions.Count)
        {
            Debug.LogError("amount of Messages and Actions must match!!!");
            return;
        }

        foreach (string message in messages) 
        {
            var GOinstance = Instantiate(_optionView.gameObject, _bubbleRect);
            OptionItemView optionInstance = GOinstance.GetComponent<OptionItemView>();
            optionInstance.SetText(message);
            _cachedOptionViews.Add(optionInstance);
        }
        for (int i = 0; i < _cachedOptionViews.Count; i++)
        {
            _cachedOptionViews[i].SetButtonAction(actions[i]);
        }
        _optionView.gameObject.SetActive(false);
    }

    private void ClearAllOptions()
    {
        throw new NotImplementedException();
    }
}
