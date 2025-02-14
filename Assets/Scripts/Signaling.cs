using UnityEngine;

public class Signaling : MonoBehaviour
{
    private float _currentVolume = 0f;
    private float _transitionSpeed = 0.1f;
    private float _volume = 0;

    private void Update()
    {
        Sound(_volume);
    }

    public void Sound(float volume)
    {
        _volume = volume;
        _currentVolume = Mathf.MoveTowards(_currentVolume, _volume, _transitionSpeed * Time.deltaTime);
    }
}
