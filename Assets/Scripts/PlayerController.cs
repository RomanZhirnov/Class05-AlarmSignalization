using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Vector2 _direction;
    private AudioSource _audioSource;

    [SerializeField] float _speed = 0.1f;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        if (Input.GetAxis("Horizontal") != 0 | Input.GetAxisRaw("Vertical") != 0)
        {
            _rb2d.MovePosition(_rb2d.position + _direction * Time.deltaTime * _speed);

            Sound();
        }
    }

    private void Sound()
    {
        if (_audioSource.isPlaying)
        {
            return;
        }

        _audioSource?.Play();
    }
}
