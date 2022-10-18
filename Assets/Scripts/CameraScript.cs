using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform _player;
    private Vector3 _targetPosition;
    [SerializeField] private float _speed;
    
    private void Start()
    {
        //_player = GameObject.FindGameObjectWithTag("Player").transform;
        _player = GameObject.FindObjectOfType<PlayerController>().transform;
        //_speed = 5f;
    }

    private void Update()
    {
        _targetPosition.x = _player.position.x;
        _targetPosition.y = _player.position.y;
        _targetPosition.z = -10;

        Vector3 newPosition = Vector3.Lerp(transform.position, _targetPosition, _speed);
        
        transform.position = newPosition;
    }
}