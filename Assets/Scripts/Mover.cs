using UnityEngine;

public class Mover : MonoBehaviour
{
    private const float Threshold = 0.1f;

    [SerializeField] private float _speed = 3f;

    public void MoveTowardPosition(Transform position)
    {
        transform.LookAt(position.position);

        transform.position = Vector3.MoveTowards(transform.position, position.position, _speed * Time.deltaTime);
    }

    public bool HasReachedTrigger(Transform position)
    {
        return (position.position - transform.position).sqrMagnitude > Threshold * Threshold;
    }
}
