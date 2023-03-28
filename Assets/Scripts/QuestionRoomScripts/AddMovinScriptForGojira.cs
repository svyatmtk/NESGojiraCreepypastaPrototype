using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMovinScriptForGojira : MonoBehaviour
{
    public GameObject Player;
    public Transform Target; 
    public float Speed = 5f; 

    private bool _isMoving;


    public void StartMoving()
    {
        if (_isMoving) return;
        _isMoving = true;
        StartCoroutine(MoveToTargetCoroutine());
    }

    private IEnumerator MoveToTargetCoroutine()
    {
        while (Player.transform.position != Target.position)
        {
            var direction = (Target.position - Player.transform.position).normalized;
            Player.transform.position += direction * Speed * Time.deltaTime;
            PlayerController.Instance.StateSet = States.Run;
            yield return null;
        }
        _isMoving = false;
    }
}
