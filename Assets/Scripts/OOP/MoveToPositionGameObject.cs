
using UnityEngine;

public class MoveToPositionGameObject : MonoBehaviour
{
    private Vector3 _targetPosition;

    private float _moveSpeed;

    private void Update()
    {
        Move(Time.deltaTime);
        TestReachedTargetPosition();
    }

    private void Move(float deltaTime)
    {
        Vector3 direction = (_targetPosition - transform.position).normalized;

        transform.position += direction * (deltaTime * _moveSpeed);
    }

    private void TestReachedTargetPosition()
    {
        float reachedTargetDistance = 1f;
        if (Vector3.Distance(transform.position, _targetPosition) <=
            reachedTargetDistance)
        {
            _targetPosition = GetRandomPosition();
        }
    }
    
    private Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(0f, 15f),
            0f,
            Random.Range(0f, 15f));
    }

    public void SetMoveSpeed(float moveSpeed) => _moveSpeed = moveSpeed;
}