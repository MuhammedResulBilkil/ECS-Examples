/*using Unity.Entities;

public partial class MovingSystemBase : SystemBase
{
    private RefRW<RandomComponent> _randomComponent;

    protected override void OnUpdate()
    {
        _randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        foreach (MoveToPositionAspect moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
        {
            //Debug.LogFormat($"{nameof(MovingSystemBase)} - {nameof(OnUpdate)}");

            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime);
            moveToPositionAspect.TestReachedTargetPosition(_randomComponent);
            //localTransform.ValueRW.Translate(direction * SystemAPI.Time.DeltaTime * speed.ValueRO.moveSpeed);
        }

        /*Entities.ForEach((LocalTransform localTransform) =>
        {
            //localTransform.Translate(direction * SystemAPI.Time.DeltaTime * speed.ValueRO.moveSpeed);
        }).Run();#1#
    }
}*/