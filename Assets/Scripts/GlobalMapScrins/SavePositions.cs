using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePositions : MonoBehaviour
{
    public GameObject Player;
    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }
    public void Save()
    {
        PlayerPrefs.SetFloat("X", Player.transform.position.x);
        PlayerPrefs.SetFloat("Y", Player.transform.position.y);
        print("saved");
    }

    public bool Load()
    {
        if (!PlayerPrefs.HasKey("X") || !PlayerPrefs.HasKey("Y")) return false;
        var x = PlayerPrefs.GetFloat("X");
        var y = PlayerPrefs.GetFloat("Y");
        Player.transform.position = new Vector3(x, y);
        return true;
    }
}
