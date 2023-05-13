using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace UnityTemplateProjects
{
    public readonly partial struct MoveToPositionAspect : IAspect
    {
        private readonly Entity _entity;

        private readonly RefRW<LocalTransform> _localTransform;
        private readonly RefRW<Speed> _speed;
        private readonly RefRW<TargetPosition> _targetPosition;

        public void Move(float deltaTime)
        {
            float3 direction = math.normalize(_targetPosition.ValueRO.targetPosition - _localTransform.ValueRO.Position);

            _localTransform.ValueRW.Position += direction * deltaTime * _speed.ValueRO.moveSpeed;
        }
    }
}