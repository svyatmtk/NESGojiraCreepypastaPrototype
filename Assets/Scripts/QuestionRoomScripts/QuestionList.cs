using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionList
{
    [SerializeField] public static List<string> QuestionDictionary = new()
    {
        "Are you scared?",
        "Do you want to die?",
        "Do birds have teeth?",
        "Is moon rotating?",
        "First letter in your name is A?"
    };
}