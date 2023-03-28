using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOfMenu : MonoBehaviour
{
    public Image image;
    public GameObject secondPicture;
    public bool isFaded;

    void Start()
    {
        StartCoroutine(Invisible());
    }

    private void Update()
    {
        if (isFaded && secondPicture != null)
        {
            secondPicture.SetActive(true);
        }
    }

    private IEnumerator Invisible()
    {
        for (var i = 1f; i >= -0.05; i -= 0.05f)
        {
            var color = image.color;
            color.a = i;
            image.color = color;
            yield return new WaitForSeconds(0.05f);
        }

        isFaded = true;
    }
}