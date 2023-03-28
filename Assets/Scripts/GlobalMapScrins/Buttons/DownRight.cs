using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownRight : MonoBehaviour
{
    public void MoveDownRight()
    {
        StartCoroutine(GetComponent<GlobalMapScript>().MoveToNextCell(new Vector2Int(1, -1)));
    }
}
