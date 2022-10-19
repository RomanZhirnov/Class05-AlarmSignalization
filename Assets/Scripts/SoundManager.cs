using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSignal;
    [SerializeField] private Alarm _alarm;

    private AudioSource _audioSource;
    private Coroutine _playAlarmSignal;
    private float _changingSpeed = 0.1f;
    private float _targetVolume;
    //private float _currentVolume = 0f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
        _audioSource.Play();
    }

    private void OnEnable()
    {
        _alarm.Entered += Play;
        _alarm.Leaving += Stop;
    }

    private void OnDisable()
    {
        _alarm.Entered -= Play;
        _alarm.Leaving -= Stop;
    }

    //private void SoundPlay()
    //{

    //    if (_playAlarmSignal != null)
    //    {
    //        StopCoroutine(_playAlarmSignal);
    //    }

    //    _targetVolume = 1f;
    //    _playAlarmSignal = StartCoroutine(AlarmPlay(_targetVolume));


    //    else if (shouldTurnOn = false & _currentVolume != 0)
    //    {
    //        if (_playAlarmSignal != null)
    //        {
    //            StopCoroutine(_playAlarmSignal);
    //        }

    //        _targetVolume = 0f;
    //        _playAlarmSignal = StartCoroutine(AlarmPlay(_targetVolume));
    //    }
    //}

    private void Play()
    {
        if (_playAlarmSignal != null)
        {
            StopCoroutine(_playAlarmSignal);
        }

        _targetVolume = 1f;
        _playAlarmSignal = StartCoroutine(AlarmPlay(_targetVolume));
    }

    private void Stop ()
    {
        if (_playAlarmSignal != null)
        {
            StopCoroutine(_playAlarmSignal);
        }

        _targetVolume = 0f;
        _playAlarmSignal = StartCoroutine(AlarmPlay(_targetVolume));
    }

    private IEnumerator AlarmPlay(float targetVolume)
    {
        //do
        //{
        //    _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _changingSpeed);
        //    //Debug.Log($"current volume - {_currentVolume} target volume - {_targetVolume}");
        //    _audioSource.PlayOneShot(_alarmSignal, _currentVolume);
        //    yield return new WaitWhile(() => _audioSource.isPlaying);

        //} while (_currentVolume > 0 & _currentVolume < 1);
        


        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _changingSpeed);
            yield return new WaitForSeconds(1f);
        }

        //Debug.Log("Alarm OFF");
    }
}
