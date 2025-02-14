using UnityEngine;

[RequireComponent(typeof(Signaling))]
public class Trigger : MonoBehaviour
{
    private Signaling _signaling;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void Awake()
    {
        _signaling = GetComponent<Signaling>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _signaling.Sound(_maxVolume);
    }

    private void OnTriggerExit(Collider other)
    {
        _signaling.Sound(_minVolume);
    }
}
