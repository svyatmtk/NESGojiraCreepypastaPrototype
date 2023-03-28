using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoScript : QuestionManager
{
    public Button button;

    private bool _isBlinking;
    private float _blinkInterval = 0.5f;
    private float _blinkDuration = 3f;
    public Vector3 target = new Vector3(0, -5, 0);

    public GameObject Player;
    public float Speed = 5f;

    private bool _isMoving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartBlinking();
        }
    }

    private void Start()
    {
    }

    private void StartBlinking()
    {
        if (_isBlinking)
        {
            return;
        }

        StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine()
    {
        RandomFaceShow();
        StartMoving();
        _isBlinking = true;
        var endTme = Time.time + _blinkDuration;

        var startColor = button.image.color;

        while (Time.time < endTme)
        {
            button.image.color = Color.Lerp(startColor, Color.black, Mathf.PingPong(Time.time, _blinkInterval));
            yield return null;
        }

        button.image.color = startColor;
        _isBlinking = false;
        ChangeQuestion();
        Player.GetComponent<PlayerController>().enabled = true;
    }

    private void ChangeQuestion()
    {
        CommonFaceShow();
        RemoveQuestion();
        RandomQuestionShow(QuestionList.QuestionDictionary);
    }

    public void StartMoving()
    {
        if (_isMoving) return;
        _isMoving = true;
        Player.GetComponent<PlayerController>().enabled = false;
        StartCoroutine(MoveToTargetCoroutine());
    }

    private IEnumerator MoveToTargetCoroutine()
    {
        var endTme = Time.time + _blinkDuration;
        while (Vector3.Distance(Player.transform.position, target) > 0.1f)
        {
            var direction = (target - Player.transform.position).normalized;
            Player.transform.position += direction * Speed * Time.deltaTime;
            Player.GetComponentInChildren<SpriteRenderer>().flipX = true;
            PlayerController.Instance.StateSet = States.Run;

            yield return null;
        }

        PlayerController.Instance.StateSet = States.Idle;

        _isMoving = false;
    }
}