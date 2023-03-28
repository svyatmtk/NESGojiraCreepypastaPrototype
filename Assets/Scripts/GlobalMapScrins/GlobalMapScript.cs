using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GlobalMapScript : MonoBehaviour
{
    public float MoveSpeed = 999f;
    public float GridSize = 1f;
    public GameObject Map;
    public GameObject Player;
    public Color HighlightColor = Color.red;
    public SavePositions PlayerPositionLoad;

    private bool _isMoving;
    private Vector3Int _targetPos;
    private Tilemap _tilemap;

    private Color _initialColor;
    private Vector3Int _previousCell;

    public void Start()
    {
        _tilemap = Map.GetComponent<Tilemap>();
        PlayerPositionLoad = GetComponent<SavePositions>();
        _initialColor = _tilemap.color;
        if (!PlayerPositionLoad.Load())
        {
            Player.transform.position = new Vector3(-6f, 3f, 0f);
        }
        _previousCell = Vector3Int.RoundToInt(Player.transform.position / GridSize);
        _tilemap.SetTileFlags(Vector3Int.RoundToInt(Player.transform.position), TileFlags.None);
        _tilemap.SetColor(Vector3Int.RoundToInt(Player.transform.position), HighlightColor);

    }
    void Update()
    {
        if (!_isMoving)
        {
            var currentCell = Vector3Int.RoundToInt(Player.transform.position / GridSize);
            if (currentCell != _previousCell)
            {
                _tilemap.SetTileFlags(currentCell, TileFlags.None);
                _tilemap.SetColor(currentCell, HighlightColor);

                _tilemap.SetTileFlags(_previousCell, TileFlags.None);
                _tilemap.SetColor(_previousCell, _initialColor);

                _previousCell = currentCell;
            }
        }
        if (Vector3Int.RoundToInt(Player.transform.position) == _targetPos)
        {
            _isMoving = false;
        }
    }

    public IEnumerator MoveToNextCell(Vector2Int direction)
    {
        if (_isMoving)
        {
            yield break;
        }

        Vector3 currentPos = Player.transform.position;
        Vector3Int currentCell = new Vector3Int(
            Mathf.RoundToInt(currentPos.x / GridSize), 
            Mathf.RoundToInt(currentPos.y / GridSize), 
            Mathf.RoundToInt(currentPos.z / GridSize));

        Vector3Int nextCell = currentCell + new Vector3Int(direction.x, direction.y, 0);

        _targetPos = new Vector3Int(
            nextCell.x * Mathf.RoundToInt(GridSize), 
            nextCell.y * Mathf.RoundToInt(GridSize), 
            nextCell.z * Mathf.RoundToInt(GridSize));

        if (!CellExists(_targetPos))
        {
            yield break;
        }

        _isMoving = true;
        while (Player.transform.position != _targetPos)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, _targetPos, MoveSpeed * Time.deltaTime);
            yield return null;
        }

        _isMoving = false;
    }

    public bool CellExists(Vector3Int position)
    {
        var tileSet = Map.GetComponent<Tilemap>();
        return tileSet.HasTile(position);
    }

    public void DeleteSaves()
    {
        PlayerPrefs.DeleteAll();
    }
}
