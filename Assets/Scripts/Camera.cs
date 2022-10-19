using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class Camera : MonoBehaviour
{
    private Vector3 _targetPosition;
    [SerializeField] private float _speed = 10;
    [SerializeField] private Transform _playerPosition;
    

    private void Update()
    {
        _targetPosition.x = _playerPosition.position.x;
        _targetPosition.y = _playerPosition.position.y;
        _targetPosition.z = -10;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed*Time.deltaTime);
    }
}
