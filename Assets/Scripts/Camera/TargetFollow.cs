using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        var targetPosition = new Vector3(transform.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
