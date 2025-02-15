using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    private Trigger _trigger;
    private Coroutine _currentCoroutine;
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
        _trigger.Triggered += HandleTriggerChange;
    }

    private void OnDisable()
    {
        _trigger.Triggered -= HandleTriggerChange;
    }

    public IEnumerator Sound(float volume)
    {
        while (Mathf.Approximately(_currentVolume, volume) == false)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, volume, _transitionSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void HandleTriggerChange(bool isEntered)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        if (isEntered)
        {
            _currentCoroutine = StartCoroutine(Sound(_maxVolume));
        }
        else
        {
            _currentCoroutine = StartCoroutine(Sound(_minVolume));
        }
    }
}
