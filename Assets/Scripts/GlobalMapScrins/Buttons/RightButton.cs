using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
{
    public void MoveRight()
    {
        StartCoroutine(GetComponent<GlobalMapScript>().MoveToNextCell(new Vector2Int(1, 0)));
    }
}
