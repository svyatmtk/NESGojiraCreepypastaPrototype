using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLeft : MonoBehaviour
{
    public void MoveDownLeft()
    {
        StartCoroutine(GetComponent<GlobalMapScript>().MoveToNextCell(new Vector2Int(-1, -1)));
    }
}
