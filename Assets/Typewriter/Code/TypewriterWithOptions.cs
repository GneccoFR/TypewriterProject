using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TypewriterWithOptions : Typewriter
{
    [SerializeField] private OptionsHandler _optionsHandler; 


    public void LoadOptions(List<string> messages, List<UnityAction> actions)
    {
        _optionsHandler.DisplayOptions(messages, actions);
    }
}