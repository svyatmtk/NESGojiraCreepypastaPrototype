using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperRight : MonoBehaviour
{
    public void MoveUpperRight()
    {
        StartCoroutine(GetComponent<GlobalMapScript>().MoveToNextCell(new Vector2Int(1, 1)));
    }
}
