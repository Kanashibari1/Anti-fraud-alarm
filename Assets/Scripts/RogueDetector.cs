using System;
using UnityEngine;

[RequireComponent(typeof(Signaling))]
public class RogueDetector : MonoBehaviour
{
    public event Action RogueDetected;
    public event Action RogueLost;

    private void OnTriggerEnter(Collider other)
    {
        RogueDetected.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        RogueLost.Invoke();
    }
}
