using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuestionManager : MonoBehaviour
{
    public TMP_Text QuestionText;
    public GameObject Face;
    public Sprite DefeaultSprite;

    /*[SerializeField] private List<string> QuestionDictionary = new()
    {
        "Are you scared?",
        "Do you want to die?",
        "Do birds have teeth?",
        "Is moon rotating?",
        "First letter in your name is A?"
    };*/

    public List<Sprite> FaceSprites = new();

    private void Start()
    {
        RandomQuestionShow(QuestionList.QuestionDictionary);
    }

    public void RandomQuestionShow(List<string> dict)
    {
        if (IsNeedReturnToMap(dict))
        {
            SceneManager.LoadScene("EarthMap");
            return;
        }
        var rand = new System.Random();
        var randomIndex = rand.Next(0, QuestionList.QuestionDictionary.Count);
        var question = QuestionList.QuestionDictionary[randomIndex];
        QuestionList.QuestionDictionary.RemoveAt(randomIndex);
        QuestionText.text += question;
    }

    private static bool IsNeedReturnToMap(List<string> dict) => dict.Count <= 0;

    public void RandomFaceShow()
    {
        var rand = new System.Random();
        var randomIndex = rand.Next(0, FaceSprites.Count);
        Face.GetComponentInChildren<SpriteRenderer>().sprite = FaceSprites[randomIndex];
        FaceSprites.RemoveAt(randomIndex);
    }

    public void CommonFaceShow() => Face.GetComponentInChildren<SpriteRenderer>().sprite = DefeaultSprite;

    public void RemoveQuestion()
    {
        QuestionText.text = "";
    }
}

