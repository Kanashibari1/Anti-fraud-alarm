using System;
using UnityEngine;

[RequireComponent(typeof(Signaling))]
public class Trigger : MonoBehaviour
{
    public event Action<bool> OnTriggerEntered;
    public event Action<bool> OnTriggerExited;
    private readonly bool isEnter = true;
    private readonly bool isExit = false;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered.Invoke(isEnter);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExited.Invoke(isExit);
    }
}
