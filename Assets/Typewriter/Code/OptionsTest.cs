using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OptionsTest : MonoBehaviour
{
    [SerializeField] private TypewriterWithOptions _optionsTypewriter;
    [SerializeField] private List<string> _optionMessages = new List<string>();
    [SerializeField] private List<string> _bodyMessages = new List<string>();
    private List<UnityAction> _actions = new List<UnityAction>();

    private void Start()
    {
        _optionsTypewriter.LoadMessages(_bodyMessages);
        _actions.Add(new UnityAction(TestOne));
        _actions.Add(new UnityAction(TestTwo));
        _actions.Add(new UnityAction(TestThree));
        _optionsTypewriter.LoadOptions(_optionMessages, _actions);
    }

    private void TestOne()
    {
        Debug.Log("One!");
    }

    private void TestTwo()
    {
        Debug.Log("Two!!");
    }

    private void TestThree()
    {
        Debug.Log("Three!!!");
    }
}
