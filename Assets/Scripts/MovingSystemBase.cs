using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityTemplateProjects;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (MoveToPositionAspect moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
        {
            Debug.LogFormat($"{nameof(MovingSystemBase)} - {nameof(OnUpdate)}");

            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime);
            //localTransform.ValueRW.Translate(direction * SystemAPI.Time.DeltaTime * speed.ValueRO.moveSpeed);
        }

        /*Entities.ForEach((LocalTransform localTransform) =>
        {
            //localTransform.Translate(direction * SystemAPI.Time.DeltaTime * speed.ValueRO.moveSpeed);
        }).Run();*/
    }
}
