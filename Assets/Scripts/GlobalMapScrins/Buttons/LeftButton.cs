using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    public void MoveLeft()
    {
        StartCoroutine(GetComponent<GlobalMapScript>().MoveToNextCell(new Vector2Int(-1, 0)));
    }
}
