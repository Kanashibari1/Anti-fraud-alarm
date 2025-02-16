using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    private Coroutine _coroutine;
    private RogueDetector _trigger;
    private float _currentVolume = 0f;
    private float _transitionSpeed = 0.1f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void Awake()
    {
        _trigger = GetComponent<RogueDetector>();
    }

    private void OnEnable()
    {
        _trigger.RogueDetected += ActiveSound;
        _trigger.RogueLost += DeactivateSound;
    }

    private void OnDisable()
    {
        _trigger.RogueDetected -= ActiveSound;
        _trigger.RogueLost -= DeactivateSound;
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

    private void ActiveSound()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Sound(_maxVolume));
    }

    private void DeactivateSound()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Sound(_minVolume));
    }
}
