using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedGrow : MonoBehaviour
{
    private RectTransform redImage;
    public AudioSource ScarySoundSource;

    private void Awake()
    {
        redImage = GetComponent<RectTransform>();
    }
    void Start()
    {
        StartCoroutine(RedGrowing());
    }

    private IEnumerator RedGrowing()
    {
        for (var i = 0f; i < 10f; i += 0.05f)
        {
            redImage.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine(ScarySoundOn());
    }

    private IEnumerator ScarySoundOn()
    {
        ScarySoundSource.Play();
        yield return new WaitForSeconds(5f);
        TurnGameOff();
    }

    private void TurnGameOff()
    {
        Debug.Log("игра выключена");
        Application.Quit();
    }

}
