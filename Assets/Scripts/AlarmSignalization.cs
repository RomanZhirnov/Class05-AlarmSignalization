using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSignalization : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSignal;

    private AudioSource _audioSource;
    private Coroutine _playAlarmSignal;
    private float _changingSpeed = 0.1f;
    private float _targetVolume;
    private float _currentVolume = 0f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            _targetVolume = 1f;

            if (_playAlarmSignal != null)
            {
                StopCoroutine(_playAlarmSignal);
            }

            _playAlarmSignal =  StartCoroutine(AlarmPlay(_targetVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            _targetVolume = 0f;

            if (_playAlarmSignal != null)
            {
                StopCoroutine(_playAlarmSignal);
            }

            _playAlarmSignal = StartCoroutine(AlarmPlay(_targetVolume));
        }
    }

    private IEnumerator AlarmPlay(float targetVolume)
    {
        Debug.Log("Alarm ON");

        do
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _changingSpeed);

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
