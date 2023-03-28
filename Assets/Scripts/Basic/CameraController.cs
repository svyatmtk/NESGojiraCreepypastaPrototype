using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float XShift { get; set; } = 5.5f;
    [SerializeField] public float YShift { get; set; } = 3.69f;

    private void Awake()
    {
        if (!_player)
        {
            _player = FindObjectOfType<PlayerController>().transform;
        }
    }

    private void Update()
    {
        if (_player == null) return;
        var temp = transform.position;
        temp.x = _player.position.x + XShift;
        temp.y = _player.position.y + YShift; 

        transform.position = temp;

    }
}
