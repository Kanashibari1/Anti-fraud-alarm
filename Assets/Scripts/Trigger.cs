using System;
using UnityEngine;

[RequireComponent(typeof(Signaling))]
public class Trigger : MonoBehaviour
{
    public event Action<bool> Triggered;

    private void OnTriggerEnter(Collider other)
    {
        Triggered.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Triggered.Invoke(false);
    }
}
