using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Rogue : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoint;

    private Mover _mover;
    private int _currentWayPoint = 0;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _mover.MoveTowardPosition(_wayPoint[_currentWayPoint]);

        if (_mover.HasReachedTrigger(_wayPoint[_currentWayPoint]) == false)
        {
            ChooseNextPoint();
        }
    }

    private void ChooseNextPoint()
    {
        _currentWayPoint = ++_currentWayPoint % _wayPoint.Length;
    }
}
