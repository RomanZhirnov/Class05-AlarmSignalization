using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSignalization : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSignal;

    private AudioSource _audioSource;
    private float _changingSpeed;
    private float _targetVolume = 1f;
    private float _currentVolume = 0f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _changingSpeed = 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            _targetVolume = 1f;
            StartCoroutine(AlarmPlay());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            _targetVolume = 0f;
        }
    }

    private IEnumerator AlarmPlay()
    {
        Debug.Log("Alarm ON");

        do
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _changingSpeed);

            if (_currentVolume <= 0)
            {
                break;            
            }

            Debug.Log($"current volume - {_currentVolume} target volume - {_targetVolume}");
            _audioSource.PlayOneShot(_alarmSignal, _currentVolume);
            yield return new WaitWhile(() => _audioSource.isPlaying);

        } while (_currentVolume > 0);
        
        Debug.Log("Alarm OFF");
    }
}
