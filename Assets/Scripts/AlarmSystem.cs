using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
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

    private IEnumerator FadeVolume(float volume)
    {
        while (Mathf.Approximately(_currentVolume, volume) == false)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, volume, _transitionSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void ActiveSound()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeVolume(_maxVolume));
    }

    private void DeactivateSound()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeVolume(_minVolume));
    }
}
