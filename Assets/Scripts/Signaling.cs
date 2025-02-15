using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    private Trigger _trigger;
    private float _currentVolume = 0f;
    private float _transitionSpeed = 0.1f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void Awake()
    {
        _trigger = GetComponent<Trigger>();
    }

    private void OnEnable()
    {
        _trigger.OnTriggerEntered += ActiveSound;
        _trigger.OnTriggerExited += DeactivateSound;
    }

    private void OnDisable()
    {
        _trigger.OnTriggerEntered -= ActiveSound;
        _trigger.OnTriggerExited -= DeactivateSound;
    }

    public IEnumerator Sound(float volume)
    {
        while (Mathf.Approximately(_currentVolume, volume) == false)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, volume, _transitionSpeed * Time.deltaTime);
            Debug.Log(_currentVolume);
            yield return null;
        }
    }

    private void ActiveSound(bool isEnter)
    {
        StartCoroutine(Sound(_maxVolume));
    }

    private void DeactivateSound(bool isExit)
    {
        StartCoroutine(Sound(_minVolume));
    }
}
