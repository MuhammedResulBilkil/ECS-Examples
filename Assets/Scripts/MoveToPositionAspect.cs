using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity _entity;

    private readonly RefRW<LocalTransform> _localTransform;
    private readonly RefRO<Speed> _speed;
    private readonly RefRW<TargetPosition> _targetPosition;

    public void Move(float deltaTime)
    {
        float3 direction = math.normalize(_targetPosition.ValueRO.targetPosition - _localTransform.ValueRO.Position);

        _localTransform.ValueRW.Position += direction * deltaTime * _speed.ValueRO.moveSpeed;
    }

    public void TestReachedTargetPosition(RefRW<RandomComponent> randomComponent)
    {
        float reachedTargetDistance = 1f;
        if (math.distancesq(_localTransform.ValueRO.Position, _targetPosition.ValueRO.targetPosition) <=
            reachedTargetDistance)
        {
            //Debug.LogFormat($"Distance = {math.distance(_localTransform.ValueRO.Position, _targetPosition.ValueRO.targetPosition)}");
            //Debug.LogFormat($"Distance Squared= {math.distancesq(_localTransform.ValueRO.Position, _targetPosition.ValueRO.targetPosition)}");

            _targetPosition.ValueRW.targetPosition = GetRandomPosition(randomComponent);

            //Debug.LogFormat($"Random Target Pos = " + _targetPosition.ValueRO.targetPosition);
        }
    }

    private float3 GetRandomPosition(RefRW<RandomComponent> randomComponent)
    {
        return new float3(
            randomComponent.ValueRW.random.NextFloat(0f, 15f),
            0f,
            randomComponent.ValueRW.random.NextFloat(0f, 15f));
    }
}