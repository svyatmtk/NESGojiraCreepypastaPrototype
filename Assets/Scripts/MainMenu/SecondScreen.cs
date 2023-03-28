using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SecondScreen : MonoBehaviour
{
    public AudioSource Audio;
    [CanBeNull] public GameObject SelectScreen;
    public GameObject text;

    private void Awake()
    {
        Audio.Play();
        StartCoroutine(BlinkingText());
    }

    private void Update()
    {
        if (!Input.anyKeyDown) return;
        SelectScreen.SetActive(true);
    }

    private IEnumerator BlinkingText()
    {
        while (true)
        {
            text.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            text.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}