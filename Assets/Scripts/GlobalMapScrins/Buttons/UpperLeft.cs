using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperLeft : MonoBehaviour
{
    public void MoveUpperLeft()
    {
        StartCoroutine(GetComponent<GlobalMapScript>().MoveToNextCell(new Vector2Int(-1, 1)));
    }
}
