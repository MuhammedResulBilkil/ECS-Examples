using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;

[BurstCompile]
public partial struct MovingISystem : ISystem
{
    private RefRW<RandomComponent> _randomComponent;
    private float _deltaTime;

    public void OnUpdate(ref SystemState state)
    { 
        _randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
        _deltaTime = SystemAPI.Time.DeltaTime;

        JobHandle jobHandle = new MoveJob
        {
            deltaTime = _deltaTime
        }.ScheduleParallel(state.Dependency);
        
        jobHandle.Complete();
        
        new TestReachedTargetPositionJob
        {
            randomComponent = _randomComponent
        }.Run();
    }
}

[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;

    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.Move(deltaTime);
    }
}

[BurstCompile]
public partial struct TestReachedTargetPositionJob : IJobEntity
{ 
    [NativeDisableUnsafePtrRestriction] 
    public RefRW<RandomComponent> randomComponent;

    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.TestReachedTargetPosition(randomComponent);
    }
}