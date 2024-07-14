using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typewriter : MonoBehaviour
{
    [SerializeField] private TypewriterMachine _typewriterMachine;
    [SerializeField] private RectTransform _typewriterRect;
    [SerializeField] private bool _showOnStart;


    private void Start()
    {
        if (_showOnStart)
            _typewriterMachine.StartOrEndSentence();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _typewriterMachine.Abort();
            HideBubble();
        }
        if (Input.GetKeyDown(KeyCode.Space))
            _typewriterMachine.StartOrEndSentence();
    }

    public void LoadMessages(List<string> messages)
    {
        ShowBubble();
        _typewriterMachine.LoadStrings(messages);
    }

    public void HideBubble()
    {
        _typewriterRect.gameObject.SetActive(false);
    }

    public void ShowBubble()
    {
        _typewriterRect.gameObject.SetActive(true);
    }
}
