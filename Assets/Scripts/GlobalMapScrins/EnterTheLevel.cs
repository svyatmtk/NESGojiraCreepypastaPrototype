using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterTheLevel : MonoBehaviour
{
    public GameObject Map;
    public Button LevelButton;
    public SavePositions PlayerPositionsSave;

    public Dictionary<Vector2Int, string> LevelDict = new()
    {
        { new Vector2Int(-4, 1), "QuestionRoom1" },
        { new Vector2Int(-1, -1), "FirstLevel" },
        { new Vector2Int(4, 0), "RedLevel" }
    };
    public GameObject Player;
    public float GridSize = 1f;
    public GameObject NotFoundLevel;

    private void Start()
    {
        PlayerPositionsSave = GetComponent<SavePositions>();
        LevelButton.onClick.AddListener(LevelStarter);
    }

    private void LevelStarter()
    {
        var currentCell = GetCurrentCell();

        if (LevelDict.TryGetValue(currentCell, out var levelName))
        {
            PlayerPositionsSave.Save();
            SceneManager.LoadScene(levelName);
        }
        else
        {
            StartCoroutine(ShowNoFoundButton());
        }
    }

    private Vector2Int GetCurrentCell()
    {
        var currentPos = Player.transform.position;
        var currentCell = new Vector2Int(
            Mathf.RoundToInt(currentPos.x / GridSize),
            Mathf.RoundToInt(currentPos.y / GridSize));
        return currentCell;
    }

    private IEnumerator ShowNoFoundButton()
    {
        NotFoundLevel.SetActive(true);
        while (!Input.anyKeyDown)
        {
            GetComponent<GlobalMapScript>().enabled = false;
            yield return null;
        }
        NotFoundLevel.SetActive(false);
        GetComponent<GlobalMapScript>().enabled = true;
    }
}
