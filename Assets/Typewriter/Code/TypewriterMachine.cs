using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterMachine : MonoBehaviour
{
    [SerializeField] private Typewriter _textBubbleView;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;
    [SerializeField] private float _timeBetweenCharacters;
    [SerializeField] private float _timeBetweenWords;
    [SerializeField] private List<string> _strings = new List<string>();
    private int i = 0;
    private bool _isShowing = false;
    private bool _skip = false;


    private void Start()
    {
        _button.onClick.AddListener(StartOrEndSentence);
    }

    public void LoadStrings(List<string> messages)
    {
        i = 0;
        _strings = messages;
        StartOrEndSentence();
    }

    public void StartOrEndSentence()
    {
        if (_isShowing)
            _skip = true;

        if (_strings.Count <= 0)
        {
            Debug.LogWarning("No strings loaded!!");
            return;
        }
        if (i <= _strings.Count - 1)
        {
            _text.text = _strings[i].ToString();
            StartCoroutine(ShowTextCoroutine());
        }
        else
            _textBubbleView.HideBubble();
    }

    private IEnumerator ShowTextCoroutine()
    {
        _text.ForceMeshUpdate();
        int visibleCharacters = _text.textInfo.characterCount;
        int counter = 0;
        _isShowing = true;

        while (_isShowing)
        {
            int visibleCount = counter % (visibleCharacters + 1);
            _text.maxVisibleCharacters = visibleCount;

            counter += 1;

            if(_skip)
            {
                _text.maxVisibleCharacters = visibleCharacters;
                _skip = false;
                i += 1;
                _isShowing = false;
            }

            if (visibleCount >= visibleCharacters)
            {
                i += 1;
                break;
            }

            yield return new WaitForSeconds(_timeBetweenCharacters);
        }

        _isShowing = false;
    }

    internal void Abort()
    {
        StopAllCoroutines();
        i= 0;
        _isShowing = false;
        _skip = false;
    }
}
